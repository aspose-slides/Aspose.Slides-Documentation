---
title: Qt'de PowerPoint Belgeleriyle Çalışma
type: docs
weight: 60
url: /tr/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt creator
- Qt uygulaması
- çok platformlu
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Qt Creator ve Visual Studio ile Aspose.Slides for C++ kullanarak, çapraz platform uygulamalarında PowerPoint ve OpenDocument sunumlarını oluşturun, yükleyin ve düzenleyin."
---
## **Giriş**

Qt, C++ tabanlı, çapraz platform uygulama geliştirme çerçevesidir ve masaüstü, mobil ve gömülü sistem uygulamalarının çeşitli türlerini geliştirmek için yaygın olarak kullanılır. Aspose.Slides for C++ Qt içinde entegrasyon sağlayarak Qt uygulamalarınızda PowerPoint belgelerini oluşturabilir ve manipüle edebilirsiniz.

## **Qt Creator içinde Aspose.Slides for C++ Kullanımı**

Qt uygulamanızda Aspose.Slides for C++ kullanmak için API'nin en son sürümünü [downloads](https://downloads.aspose.com/slides/tr/cpp) bölümünden indirin. API indirildikten sonra C++ kütüphanesini Qt Creator veya Visual Studio içinde entegre edebilirsiniz.

Qt Creator'da geliştirilen bir Qt Konsol Uygulaması içinde Aspose.Slides for C++ kütüphanesini entegre etmek ve kullanmak için lütfen aşağıdaki adımları izleyin:

- Qt Creator'ı açın ve yeni bir *Qt Console Application* oluşturun.

![qt_console_application](qt-console-application.png)

- *Build System* açılır listesinden QMake seçeneğini seçin.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Uygun kiti seçin ve sihirbazı tamamlayın.
- Aspose.Slides for C++'ın çıkarılmış paketindeki aspose-slides-cpp-21.02 klasörünü projenin kök dizinine kopyalayın.

![lib_files](aspose.slides-lib-files.png)

- lib ve include klasörlerine yollar eklemek için, sol panelde projeye sağ tıklayın ve *Add Library* seçeneğini seçin.

![qt_add_library](qt_add_library.png)

- *External Library* seçeneğini seçin ve lib klasörlerinin yollarını tek tek gezerek ekleyin.

![todo:image_alt_text](qt-add-external-library.png)

- İşlem tamamlandığında, .pro proje dosyanız aşağıdaki girişleri içerecektir:

![qt_pro_file.png](qt-pro-file.png)

- Uygulamayı derleyin ve bütün entegrasyon işlemi tamamlanmış olur.  

{{% alert color="primary" %}}
Not: Daha fazla bilgi için [tam demo projesine](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) bakın.
{{% /alert %}}

## **Visual Studio içinde Qt Uygulamalarında Aspose.Slides for C++ Kullanımı**

Visual Studio kullanarak bir Qt uygulaması geliştirmek için [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123) yüklemeniz gerekir. Kurulumu tamamladıktan sonra API'nin en son sürümünü [downloads](https://downloads.aspose.com/slides/tr/cpp) bölümünden indirin ve aşağıdaki adımları izleyin:

- Microsoft Visual Studio'yu açın ve yeni bir *Qt Console Application* oluşturun.

![VS_Console_Application.png](vs-console-application.png)

- Uygun kiti seçin ve sihirbazı tamamlayın.
- Aspose.Slides for C++ kütüphanesini entegre etmek ve kullanmak için projeye sağ tıklayın ve *Manage NuGet Packages...* seçeneğini seçin.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Gerekli *Aspose.Slides.Cpp* paketini bulun ve yükleyin.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Projeyi derleyin ve bütün entegrasyon işlemi tamamlanmış olur.  

{{% alert color="primary" %}}
Not: Daha fazla bilgi için [tam demo projesine](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) bakın.
{{% /alert %}}