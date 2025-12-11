---
title: Travailler avec des documents PowerPoint dans Qt
type: docs
weight: 60
url: /fr/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt Creator
- Application Qt
- multiplateforme
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Utilisez Aspose.Slides pour C++ avec Qt Creator et Visual Studio pour créer, charger et modifier des présentations PowerPoint et OpenDocument dans des applications multiplateformes."
---

Qt est un cadre de développement d'applications multiplateforme basé sur C++ qui est largement utilisé pour créer une variété d'applications de bureau, mobiles et systèmes embarqués. Aspose.Slides for C++ peut être intégré à Qt afin de créer et de manipuler des documents PowerPoint dans vos applications Qt.

## **Utilisation d'Aspose.Slides for C++ avec Qt Creator**

Pour utiliser Aspose.Slides for C++ dans votre application Qt, téléchargez la dernière version de l'API depuis la section [downloads](https://downloads.aspose.com/slides/cpp). Une fois l'API téléchargée, vous pouvez intégrer la bibliothèque C++ dans Qt Creator ou Visual Studio.

Pour intégrer et utiliser la bibliothèque Aspose.Slides for C++ dans une application console Qt développée avec Qt Creator, veuillez suivre les étapes ci-dessous :

- Ouvrez Qt Creator et créez une nouvelle *Qt Console Application*.

![Application console Qt](qt-console-application.png)

- Sélectionnez l'option QMake dans la liste déroulante *Build System*.

![Sélection QMake](qt-console-application-qmake.png)

- Sélectionnez le kit approprié et terminez l'assistant.
- Copiez le dossier aspose-slides-cpp-21.02 du package extrait d'Aspose.Slides for C++ à la racine du projet.

![Fichiers de bibliothèque](aspose.slides-lib-files.png)

- Pour ajouter les chemins aux dossiers lib et include, cliquez avec le bouton droit sur le projet dans le panneau de gauche et sélectionnez *Add Library*.

![Ajouter une bibliothèque](qt_add_library.png)

- Sélectionnez l'option External Library et parcourez les chemins pour inclure les dossiers lib un par un.

![todo:image_alt_text](qt-add-external-library.png)

- Une fois terminé, votre fichier de projet .pro contiendra les entrées suivantes :

![qt_pro_file.png](qt-pro-file.png)

- Compilez l'application et l'intégration est terminée.  

{{% alert color="primary" %}}

Remarque : Consultez le [projet de démonstration complet](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) pour plus d'informations.

{{% /alert %}}

## **Utilisation d'Aspose.Slides for C++ dans les applications Qt avec Visual Studio**

Pour développer une application Qt avec Visual Studio, vous devez installer [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). Une fois l'installation effectuée, téléchargez la dernière version de l'API depuis la section [downloads](https://downloads.aspose.com/slides/cpp) et suivez les étapes ci-dessous :

- Ouvrez Microsoft Visual Studio et créez une nouvelle *Qt Console Application*.

![Application console Visual Studio](vs-console-application.png)

- Sélectionnez le kit approprié et terminez l'assistant.
- Pour intégrer et utiliser la bibliothèque Aspose.Slides for C++, cliquez avec le bouton droit sur le projet et sélectionnez *Manage NuGet Packages...*.

![Gérer les packages NuGet](vs-manage-nuget-package.png)

- Recherchez et installez le package *Aspose.Slides.Cpp* requis.

![Trouver NuGet](vs-find-nuget.png)

- Compilez le projet et l'intégration est terminée.  

{{% alert color="primary" %}}

Remarque : Consultez le [projet de démonstration complet](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) pour plus d'informations.

{{% /alert %}}