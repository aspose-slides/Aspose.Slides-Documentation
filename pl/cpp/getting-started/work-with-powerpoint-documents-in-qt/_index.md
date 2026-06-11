---  
title: Praca z dokumentami PowerPoint w Qt  
type: docs  
weight: 60  
url: /pl/cpp/work-with-powerpoint-documents-in-qt/  
keywords:  
- Qt Creator  
- aplikacja Qt  
- wieloplatformowy  
- PowerPoint  
- OpenDocument  
- prezentacja  
- C++  
- Aspose.Slides  
description: "Użyj Aspose.Slides for C++ z Qt Creator i Visual Studio, aby tworzyć, ładować i edytować prezentacje PowerPoint oraz OpenDocument w aplikacjach wieloplatformowych."  
---
## **Wprowadzenie**

Qt jest opartym na C++ wieloplatformowym frameworkiem do tworzenia aplikacji, który jest szeroko stosowany do opracowywania różnorodnych aplikacji desktopowych, mobilnych oraz systemów wbudowanych. Aspose.Slides for C++ może być zintegrowany z Qt w celu tworzenia i manipulowania dokumentami PowerPoint w aplikacjach Qt.

## **Używanie Aspose.Slides for C++ w Qt Creator**

Aby używać Aspose.Slides for C++ w swojej aplikacji Qt, pobierz najnowszą wersję API z sekcji [downloads](https://downloads.aspose.com/slides/pl/cpp). Po pobraniu API możesz zintegrować bibliotekę C++ w Qt Creator lub Visual Studio.

Aby zintegrować i używać biblioteki Aspose.Slides for C++ w aplikacji konsolowej Qt rozwijanej w Qt Creator, postępuj zgodnie z poniższymi krokami:

- Otwórz Qt Creator i utwórz nową *Qt Console Application*.

![qt_console_application](qt-console-application.png)

- Wybierz opcję QMake z listy rozwijanej *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Wybierz odpowiedni zestaw (kit) i zakończ kreator.
- Skopiuj folder aspose-slides-cpp-21.02 z rozpakowanego pakietu Aspose.Slides for C++ do katalogu głównego projektu.

![lib_files](aspose.slides-lib-files.png)

- Aby dodać ścieżki do folderów lib i include, kliknij prawym przyciskiem myszy projekt w lewym panelu i wybierz *Add Library*.

![qt_add_library](qt_add_library.png)

- Wybierz opcję External Library i przeglądaj ścieżki do folderów lib pojedynczo.

![todo:image_alt_text](qt-add-external-library.png)

- Po zakończeniu, plik projektu .pro będzie zawierał następujące wpisy:

![qt_pro_file.png](qt-pro-file.png)

- Zbuduj aplikację i zakończ integrację.  

{{% alert color="primary" %}}
Uwaga: Zobacz [pełny projekt demo](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) po więcej informacji.
{{% /alert %}}

## **Używanie Aspose.Slides for C++ w aplikacjach Qt w Visual Studio**

Aby opracować aplikację Qt przy użyciu Visual Studio, musisz zainstalować [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). Po zainstalowaniu pobierz najnowszą wersję API z sekcji [downloads](https://downloads.aspose.com/slides/pl/cpp) i postępuj zgodnie z poniższymi krokami:

- Otwórz Microsoft Visual Studio i utwórz nową *Qt Console Application*.

![VS_Console_Application.png](vs-console-application.png)

- Wybierz odpowiedni zestaw (kit) i zakończ kreator.
- Aby zintegrować i używać biblioteki Aspose.Slides for C++, kliknij prawym przyciskiem myszy projekt i wybierz *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Znajdź i zainstaluj wymaganą paczkę *Aspose.Slides.Cpp*.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Zbuduj projekt i zakończ integrację.  

{{% alert color="primary" %}}
Uwaga: Zobacz [pełny projekt demo](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) po więcej informacji.
{{% /alert %}}