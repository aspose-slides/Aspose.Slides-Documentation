---
title: ทำงานกับเอกสาร PowerPoint ใน Qt
type: docs
weight: 60
url: /th/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt Creator
- แอปพลิเคชัน Qt
- ข้ามแพลตฟอร์ม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ใช้ Aspose.Slides for C++ กับ Qt Creator และ Visual Studio เพื่อสร้าง โหลด และแก้ไขงานนำเสนอ PowerPoint และ OpenDocument ในแอปพลิเคชันข้ามแพลตฟอร์ม"
---
## **บทนำ**

Qt เป็นกรอบงานพัฒนาแอปพลิเคชันแบบครอสแพลตฟอร์มที่ใช้ภาษา C++ ซึ่งได้รับการใช้งานอย่างกว้างขวางเพื่อพัฒนาแอปพลิเคชันบนเดสก์ท็อป, มือถือ, และระบบฝังตัวต่าง ๆ Aspose.Slides for C++ สามารถผสานรวมกับ Qt เพื่อสร้างและจัดการเอกสาร PowerPoint ในแอปพลิเคชัน Qt ของคุณได้

## **การใช้ Aspose.Slides for C++ ใน Qt Creator**

เพื่อใช้ Aspose.Slides for C++ ในแอปพลิเคชัน Qt ของคุณ ดาวน์โหลดเวอร์ชันล่าสุดของ API จากส่วน [downloads](https://downloads.aspose.com/slides/th/cpp) หลังจากดาวน์โหลด API แล้ว คุณสามารถผสานรวมไลบรารี C++ ภายใน Qt Creator หรือ Visual Studio ได้

เพื่อผสานรวมและใช้ไลบรารี Aspose.Slides for C++ ภายในแอปพลิเคชันคอนโซล Qt ที่พัฒนาใน Qt Creator โปรดทำตามขั้นตอนต่อไปนี้:

- เปิด Qt Creator และสร้าง *Qt Console Application* ใหม่

![qt_console_application](qt-console-application.png)

- เลือกตัวเลือก QMake จากรายการดรอปดาวน์ *Build System*

![qt_console_application_qmake](qt-console-application-qmake.png)

- เลือกคิทที่เหมาะสมและจบวิซาร์ด
- คัดลอกโฟลเดอร์ aspose-slides-cpp-21.02 จากแพ็คเกจที่แตกไฟล์ของ Aspose.Slides for C++ ไปยังโฟลเดอร์รากของโครงการ

![lib_files](aspose.slides-lib-files.png)

- เพื่อเพิ่มเส้นทางไปยังโฟลเดอร์ lib และ include ให้คลิกขวาที่โครงการในแถบด้านซ้ายและเลือก *Add Library*

![qt_add_library](qt_add_library.png)

- เลือกตัวเลือก External Library แล้วเรียกดูเส้นทางไปยังโฟลเดอร์ lib ทีละโฟลเดอร์

![todo:image_alt_text](qt-add-external-library.png)

- เสร็จแล้ว ไฟล์โครงการ .pro ของคุณจะมีรายการต่อไปนี้:

![qt_pro_file.png](qt-pro-file.png)

- สร้างแอปพลิเคชันและคุณก็เสร็จสิ้นการผสานรวมแล้ว  

{{% alert color="primary" %}}

หมายเหตุ: ดู [โครงการสาธิตเต็ม](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) เพื่อข้อมูลเพิ่มเติม

{{% /alert %}}

## **การใช้ Aspose.Slides for C++ ในแอปพลิเคชัน Qt ภายใน Visual Studio**

เพื่อพัฒนาแอปพลิเคชัน Qt ด้วย Visual Studio คุณต้องติดตั้ง [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123) เมื่อทำการติดตั้งแล้ว ดาวน์โหลดเวอร์ชันล่าสุดของ API จากส่วน [downloads](https://downloads.aspose.com/slides/th/cpp) และทำตามขั้นตอนต่อไปนี้:

- เปิด Microsoft Visual Studio และสร้าง *Qt Console Application* ใหม่

![VS_Console_Application.png](vs-console-application.png)

- เลือกคิทที่เหมาะสมและจบวิซาร์ด
- เพื่อผสานรวมและใช้ไลบรารี Aspose.Slides for C++ ให้คลิกขวาที่โครงการและเลือก *Manage NuGet Packages...*

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- ค้นหาและติดตั้งแพ็กเกจ *Aspose.Slides.Cpp* ที่ต้องการ

![VS_Find_Nuget.png](vs-find-nuget.png)

- สร้างโครงการและคุณก็เสร็จสิ้นการผสานรวมแล้ว  

{{% alert color="primary" %}}

หมายเหตุ: ดู [โครงการสาธิตเต็ม](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) เพื่อข้อมูลเพิ่มเติม

{{% /alert %}}