---
title: Travailler avec des documents PowerPoint dans Qt
type: docs
weight: 60
url: /fr/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt creator
- Application Qt
- multi-plateforme
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Utilisez Aspose.Slides pour C++ avec Qt Creator et Visual Studio pour créer, charger et modifier des présentations PowerPoint et OpenDocument dans des applications multiplateformes."
---
## **Introduction**

Qt est un framework de développement d'applications multiplateforme basé sur C++ qui est largement utilisé pour développer une variété d'applications de bureau, mobiles et systèmes embarqués. Aspose.Slides pour C++ peut être intégré à Qt afin de créer et de manipuler des documents PowerPoint dans vos applications Qt.

## **Utilisation d'Aspose.Slides pour C++ dans Qt Creator**

Pour utiliser Aspose.Slides pour C++ dans votre application Qt, téléchargez la dernière version de l'API depuis la section [downloads](https://downloads.aspose.com/slides/fr/cpp). Une fois l'API téléchargée, vous pouvez intégrer la bibliothèque C++ dans Qt Creator ou Visual Studio.

Pour intégrer et utiliser la bibliothèque Aspose.Slides pour C++ dans une application console Qt développée avec Qt Creator, veuillez suivre les étapes ci‑dessous :

- Ouvrez Qt Creator et créez une nouvelle *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Sélectionnez l'option QMake dans la liste déroulante *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Sélectionnez le kit approprié et terminez l’assistant.
- Copiez le dossier aspose-slides-cpp-21.02 du paquet extrait d'Aspose.Slides pour C++ à la racine du projet.

![lib_files](aspose.slides-lib-files.png)

- Pour ajouter les chemins vers les dossiers lib et include, faites un clic droit sur le projet dans le panneau de gauche et sélectionnez *Add Library*.

![qt_add_library](qt_add_library.png)

- Sélectionnez l'option External Library et parcourez les chemins vers les dossiers lib un par un.

![todo:image_alt_text](qt-add-external-library.png)

- Une fois terminé, votre fichier de projet .pro contiendra les entrées suivantes :

![qt_pro_file.png](qt-pro-file.png)

- Construisez l'application et l'intégration est terminée.  

{{% alert color="info" %}}

Remarque : Consultez le [projet de démonstration complet](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) pour plus d'informations.

{{% /alert %}}

## **Utilisation d'Aspose.Slides pour C++ dans les applications Qt avec Visual Studio**

Pour développer une application Qt avec Visual Studio, vous devez installer [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). Une fois l'installation effectuée, téléchargez la dernière version de l'API depuis la section [downloads](https://downloads.aspose.com/slides/fr/cpp) et suivez les étapes ci‑dessous :

- Ouvrez Microsoft Visual Studio et créez une nouvelle *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Sélectionnez le kit approprié et terminez l’assistant.
- Pour intégrer et utiliser la bibliothèque Aspose.Slides pour C++, faites un clic droit sur le projet et sélectionnez *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Recherchez et installez le paquet *Aspose.Slides.Cpp* requis.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Construisez le projet et l'intégration est terminée.  

{{% alert color="info" %}}

Remarque : Consultez le [projet de démonstration complet](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) pour plus d'informations.

{{% /alert %}}