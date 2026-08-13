---
title: ทำงานกับเอกสาร PowerPoint ใน Qt
type: docs
weight: 60
url: /th/cpp/work-with-powerpoint-documents-in-qt/
keywords:
- Qt creator
- แอปพลิเคชัน Qt
- ข้ามแพลตฟอร์ม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ใช้ Aspose.Slides for C++ ร่วมกับ Qt Creator และ Visual Studio เพื่อสร้าง โหลด และแก้ไขงานนำเสนอ PowerPoint และ OpenDocument ในแอปพลิเคชันข้ามแพลตฟอร์ม"
---
## **บทนำ**

Qt เป็นเฟรมเวิร์กการพัฒนาแอปพลิเคชันแบบข้ามแพลตฟอร์มที่เขียนด้วย C++ ซึ่งได้รับการใช้กันอย่างแพร่หลายในการพัฒนาแอปพลิเคชันบนเดสก์ท็อป, มือถือ, และระบบฝังตัว Aspose.Slides for C++ สามารถผสานรวมกับ Qt เพื่อสร้างและจัดการเอกสาร PowerPoint ในแอปพลิเคชัน Qt ของคุณได้

## **การใช้ Aspose.Slides for C++ ใน Qt Creator**

เพื่อใช้ Aspose.Slides for C++ ในแอปพลิเคชัน Qt ของคุณ ให้ดาวน์โหลดเวอร์ชันล่าสุดของ API จากส่วน [downloads](https://downloads.aspose.com/slides/th/cpp) เมื่อดาวน์โหลด API แล้ว คุณสามารถผสานรวมไลบรารี C++ เข้าไปใน Qt Creator หรือ Visual Studio

เพื่อผสานรวมและใช้ไลบรารี Aspose.Slides for C++ ในแอปพลิเคชันคอนโซล Qt ที่พัฒนาใน Qt Creator ให้ทำตามขั้นตอนต่อไปนี้:

- เปิด Qt Creator และสร้าง *Qt Console Application* ใหม่

![qt_console_application](qt-console-application.png)

- เลือกตัวเลือก QMake จากรายการดรอปดาวน์ *Build System*

![qt_console_application_qmake](qt-console-application-qmake.png)

- เลือกชุดเครื่องมือที่เหมาะสมและดำเนินการวิซาร์ดให้เสร็จ
- คัดลอกโฟลเดอร์ aspose-slides-cpp-21.02 จากแพ็คเกจที่แตกไฟล์ของ Aspose.Slides for C++ ไปยังโฟลเดอร์รากของโปรเจกต์

![lib_files](aspose.slides-lib-files.png)

- เพื่อเพิ่มเส้นทางไปยังโฟลเดอร์ lib และ include ให้คลิกขวาที่โปรเจกต์ในแผงด้านซ้ายและเลือก *Add Library*

![qt_add_library](qt_add_library.png)

- เลือกตัวเลือก External Library แล้วเรียกดูเส้นทางไปยังโฟลเดอร์ lib ทีละโฟลเดอร์

![todo:image_alt_text](qt-add-external-library.png)

- เมื่อทำเสร็จ ไฟล์ .pro ของคุณจะมีรายการต่อไปนี้

![qt_pro_file.png](qt-pro-file.png)

- สร้างแอปพลิเคชันและการผสานรวมก็เสร็จสิ้น  

{{% alert color="info" %}}

หมายเหตุ: ดู [โครงการสาธิตเต็ม](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/QtCreator/Qt_AsposeSlides_QMake) สำหรับข้อมูลเพิ่มเติม

{{% /alert %}}

## **การใช้ Aspose.Slides for C++ ในแอปพลิเคชัน Qt ภายใน Visual Studio**

เพื่อพัฒนาแอปพลิเคชัน Qt ด้วย Visual Studio คุณต้องติดตั้ง [Qt Visual Studio Tools](https://marketplace.visualstudio.com/items?itemName=TheQtCompany.QtVisualStudioTools-19123) หลังจากติดตั้งแล้ว ให้ดาวน์โหลดเวอร์ชันล่าสุดของ API จากส่วน [downloads](https://downloads.aspose.com/slides/th/cpp) และทำตามขั้นตอนต่อไปนี้:

- เปิด Microsoft Visual Studio และสร้าง *Qt Console Application* ใหม่

![VS_Console_Application.png](vs-console-application.png)

- เลือกชุดเครื่องมือที่เหมาะสมและดำเนินการวิซาร์ดให้เสร็จ
- เพื่อผสานรวมและใช้ไลบรารี Aspose.Slides for C++ ให้คลิกขวาที่โปรเจกต์และเลือก *Manage NuGet Packages...*

![VS_Manage_NuGet_Package.png](vs-manage-nuget-package.png)

- ค้นหาและติดตั้งแพคเกจ *Aspose.Slides.Cpp* ที่ต้องการ

![VS_Find_Nuget.png](vs-find-nuget.png)

- สร้างโปรเจกต์และการผสานรวมก็เสร็จสิ้น  

{{% alert color="info" %}}

หมายเหตุ: ดู [โครงการสาธิตเต็ม](https://github.com/aspose-slides/Aspose.Slides-for-C/tree/master/QtDemos/Visual%20Studio/Qt_AsposeSlides_VS) สำหรับข้อมูลเพิ่มเติม

{{% /alert %}}