---
title: Travailler avec des documents PowerPoint dans Qt
type: docs
description: "Aspose.Slides pour C++ peut être intégré dans Qt pour créer et manipuler des documents PowerPoint dans des applications Qt."
keywords: "créer un document Qt Creator, charger un document Qt Creator, utiliser Aspose C++ avec Qt creator, charger un document Aspose C++, charger des formats pris en charge par Aspose.Slides C++"
weight: 60
url: /fr/cpp/work-with-powerpoint-documents-in-qt/
---

Qt est un framework de développement d'applications multiplateformes basé sur C++ largement utilisé pour développer une variété d'applications de bureau, mobiles et embarquées. Aspose.Slides pour C++ peut être intégré dans Qt afin de créer et manipuler des documents PowerPoint dans vos applications Qt.

## Utilisation d'Aspose.Slides pour C++ dans Qt Creator

Pour utiliser Aspose.Slides pour C++ dans votre application Qt, téléchargez la dernière version de l'API dans la section [téléchargements](https://downloads.aspose.com/slides/cpp). Une fois l'API téléchargée, vous pouvez intégrer la bibliothèque C++ dans Qt Creator ou Visual Studio.

Pour intégrer et utiliser la bibliothèque Aspose.Slides pour C++ dans une application console Qt développée dans Qt Creator, veuillez suivre les étapes ci-dessous :

- Ouvrez Qt Creator et créez une nouvelle *Application Console Qt*.

![qt_console_application](qt-console-application.png)

- Sélectionnez l'option QMake dans la liste déroulante *Système de Construction*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Sélectionnez le kit approprié et terminez l'assistant.
- Copiez le dossier aspose-slides-cpp-21.02 du package extrait d'Aspose.Slides pour C++ dans la racine du projet.

![lib_files](aspose.slides-lib-files.png)

- Pour ajouter des chemins vers les dossiers lib et include, faites un clic droit sur le projet dans le panneau de gauche et sélectionnez *Ajouter une bibliothèque*.

![qt_add_library](qt_add_library.png)

- Sélectionnez l'option Bibliothèque Externe et parcourez les chemins pour inclure les dossiers lib un par un.

![todo:image_alt_text](qt-add-external-library.png)

- Une fois terminé, votre fichier de projet .pro contiendra les entrées suivantes :

![qt_pro_file.png](qt-pro-file.png)

- Construisez l'application et vous avez terminé avec l'intégration.  

{{% alert color="primary" %}}

Remarque : Consultez le [projet de démonstration complet](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) pour plus d'informations.

{{% /alert %}}

## Utilisation d'Aspose.Slides pour C++ dans des applications Qt sous Visual Studio

Pour développer une application Qt en utilisant Visual Studio, vous devez installer [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). Une fois l'installation effectuée, téléchargez la dernière version de l'API dans la section [téléchargements](https://downloads.aspose.com/slides/cpp) et suivez les étapes ci-dessous :

- Ouvrez Microsoft Visual Studio et créez une nouvelle *Application Console Qt*.

![VS_Console_Application.png](vs-console-application.png)

- Sélectionnez le kit approprié et terminez l'assistant.
- Pour intégrer et utiliser la bibliothèque Aspose.Slides pour C++, faites un clic droit sur le projet et sélectionnez *Gérer les packages NuGet...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Trouvez et installez le package requis *Aspose.Slides.Cpp*.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Construisez le projet et vous avez terminé avec l'intégration.  

{{% alert color="primary" %}}

Remarque : Consultez le [projet de démonstration complet](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) pour plus d'informations.

{{% /alert %}}