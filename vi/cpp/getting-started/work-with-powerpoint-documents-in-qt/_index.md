---
title: Làm việc với tài liệu PowerPoint trong Qt
type: docs
weight: 60
url: /vi/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt creator
- Ứng dụng Qt
- đa nền tảng
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho C++ với Qt Creator và Visual Studio để tạo, tải và chỉnh sửa các bài thuyết trình PowerPoint và OpenDocument trong các ứng dụng đa nền tảng."
---
## **Giới thiệu**

Qt là một framework phát triển ứng dụng đa nền tảng dựa trên C++ được sử dụng rộng rãi để phát triển nhiều loại ứng dụng desktop, di động và nhúng. Aspose.Slides for C++ có thể được tích hợp vào Qt để tạo và thao tác tài liệu PowerPoint trong các ứng dụng Qt của bạn.

## **Sử dụng Aspose.Slides cho C++ trong Qt Creator**

Để sử dụng Aspose.Slides cho C++ trong ứng dụng Qt của bạn, tải phiên bản mới nhất của API từ phần [downloads](https://downloads.aspose.com/slides/vi/cpp). Sau khi tải API, bạn có thể tích hợp thư viện C++ vào Qt Creator hoặc Visual Studio.

Để tích hợp và sử dụng thư viện Aspose.Slides cho C++ trong một Ứng dụng Console Qt được phát triển bằng Qt Creator, vui lòng làm theo các bước dưới đây:

- Mở Qt Creator và tạo một *Qt Console Application* mới.

![qt_console_application](qt-console-application.png)

- Chọn tùy chọn QMake từ danh sách thả xuống *Build System*.

![qt_console_application_qmake](qt-console-application-qmake.png)

- Chọn kit phù hợp và hoàn thành wizard.
- Sao chép thư mục aspose-slides-cpp-21.02 từ gói đã giải nén của Aspose.Slides cho C++ vào thư mục gốc của dự án.

![lib_files](aspose.slides-lib-files.png)

- Để thêm đường dẫn tới các thư mục lib và include, nhấp chuột phải vào dự án trong bảng bên trái và chọn *Add Library*.

![qt_add_library](qt_add_library.png)

- Chọn tùy chọn External Library và duyệt các đường dẫn tới các thư mục lib từng cái một.

![todo:image_alt_text](qt-add-external-library.png)

- Khi hoàn tất, file dự án .pro của bạn sẽ chứa các mục sau:

![qt_pro_file.png](qt-pro-file.png)

- Xây dựng ứng dụng và bạn đã hoàn thành việc tích hợp.  

{{% alert color="info" %}}
Lưu ý: Xem [dự án demo đầy đủ](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) để biết thêm thông tin.
{{% /alert %}}

## **Sử dụng Aspose.Slides cho C++ trong các Ứng dụng Qt bằng Visual Studio**

Để phát triển một ứng dụng Qt bằng Visual Studio, bạn cần cài đặt [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123). Sau khi cài đặt, tải phiên bản mới nhất của API từ phần [downloads](https://downloads.aspose.com/slides/vi/cpp) và làm theo các bước dưới đây:

- Mở Microsoft Visual Studio và tạo một *Qt Console Application* mới.

![VS_Console_Application.png](vs-console-application.png)

- Chọn kit phù hợp và hoàn thành wizard.
- Để tích hợp và sử dụng thư viện Aspose.Slides cho C++, nhấp chuột phải vào dự án và chọn *Manage NuGet Packages...*.

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- Tìm và cài đặt gói *Aspose.Slides.Cpp* cần thiết.

![VS_Find_Nuget.png](vs-find-nuget.png)

- Xây dựng dự án và bạn đã hoàn thành việc tích hợp.  

{{% alert color="info" %}}
Lưu ý: Xem [dự án demo đầy đủ](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) để biết thêm thông tin.
{{% /alert %}}