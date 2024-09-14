# Unity-AI-tests
Experimenting and learning to Programm an AI in Unity with diffrent methodes

-Install ml agent package im Unity Package  Manager of your Projekt.

-venv Folder for the virtual python enviroment -> In Terminal first: cd folderPathOfUnityProject		<- Auf Unity Project zugreifen
								py -m venv venv    			<- folger erstellen
-In venv/script ist ein activate.bat zum activieren -> In Terminal: venv\Scripts\activate
Now there should stand (venv) folderPath>

-paython packaging seller = pip -> Terminal: python -m pip install --upgrade pip
install required packages: pytorch=open scource Libary for performing computation using data flow graphs = deep learning model -> Terminal: pip3 install torch~=2.2.1 --index-url https://download.pytorch.org/whl/cu121     
or a newer version, find it here: https://unity-technologies.github.io/ml-agents/Installation/
or -> Terminal: pip install torch torchvision torchaudio

-install ML-Agents package -> Terminal: pip install mlagents 
if you got a error try: pip install mlagents --use-feature-?=2020-resolver

-Verify if everything was correct installed -> Terminal: mlagents-learn --help

-to start the game: mlagents-learn --run-id=Test1

-with a txtdocument (in config ordner) like hier: mlagents-learn config/moveToGoal.yaml --run-id=Test4

-learning from previous brain-> Terminal: mlagents-learn config/moveToGoal.yaml --initialize-from=MoveToGoal --run-id=MoveToRun

-visuals the results-> Terminal: tensorboard --logdir results
	-> it give a localhost number -> google 'localhost6006' for example then their should be the results vidualised while training
