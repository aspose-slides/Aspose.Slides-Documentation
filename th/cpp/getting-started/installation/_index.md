---
title: การติดตั้ง
type: docs
weight: 70
url: /th/cpp/installation/
keywords:
- ติดตั้ง Aspose.Slides
- ดาวน์โหลด Aspose.Slides
- ใช้ Aspose.Slides
- การติดตั้ง Aspose.Slides
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ติดตั้ง Aspose.Slides สำหรับ C++ บน Windows จาก NuGet ใน Visual Studio หรือบน Linux จากแพ็กเกจ ZIP ด้วย CMake และตรวจสอบการติดตั้งด้วยโปรแกรมแรก"
---
## **ภาพรวม**

Aspose.Slides for C++ มีให้เลือกในสองรูปแบบ:

| รูปแบบ | ใช้สำหรับ | ที่มาของแพ็กเกจ |
|---|---|---|
| NuGet packages: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64‑บิต) และ [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32‑บิต) | โครงการ Visual Studio C++ บน Windows | NuGet |
| ZIP packages สำหรับ Windows, Linux, และ macOS | การสร้างโดยไม่มี NuGet เช่น โครงการ CMake | [หน้าดาวน์โหลด](https://releases.aspose.com/slides/cpp/) |

บทความนี้แสดงวิธีการติดตั้งแพ็กเกจ NuGet ใน Visual Studio บน Windows และวิธีใช้แพ็กเกจ ZIP กับ CMake บน Linux ทั้งสองวิธีจะสรุปด้วยขั้นตอนเดียวกัน: สร้างและรันตัวอย่างแรกใน [Create Presentations](/slides/th/cpp/create-presentation/)  

## **Windows**

บน Windows ให้เพิ่มแพ็กเกจ NuGet ไปยังโครงการ Visual Studio C++ แพ็กเกจจะติดตั้ง Dependency คือ CodePorting.Translator.Cs2Cpp.Framework ด้วยและคัดลอก DLL ที่โปรแกรมของคุณต้องการไปยังโฟลเดอร์ผลลัพธ์ของการสร้าง

เลือกแพ็กเกจตามแพลตฟอร์มที่คุณสร้าง: **Aspose.Slides.Cpp** สำหรับ x64 และ **Aspose.Slides.Cpp.x86** สำหรับ Win32 (x86) แพ็กเกจ Aspose.Slides.Cpp จะไม่ถูกนำไปใช้กับการสร้าง Win32 ทำให้คอมไพเลอร์ไม่พบ Header

แพ็กเกจ ZIP สำหรับ Windows มีให้ดาวน์โหลดจาก [หน้าดาวน์โหลด](https://releases.aspose.com/slides/cpp/)  

### **วิธีที่ 1: ติดตั้งหรืออัปเดต Aspose.Slides ผ่าน NuGet Package Manager**

1. เปิด Microsoft Visual Studio  
2. สร้างโครงการ C++ **Console App** หรือเปิดโครงการที่มีอยู่  
3. ใน **Solution Explorer** คลิกขวาที่โครงการแล้วเลือก **Manage NuGet Packages** (หรือไปที่ **Project** > **Manage NuGet Packages**)  
4. ใต้ **Browse** ค้นหา *Aspose.Slides.Cpp*  
![Searching for Aspose.Slides.Cpp in the NuGet Package Manager](installation_1.png)  
5. คลิก **Aspose.Slides.Cpp** (หรือ **Aspose.Slides.Cpp.x86** สำหรับการสร้าง 32‑บิต) แล้วคลิก **Install**  
   * หากคุณได้ติดตั้ง Aspose.Slides แล้วและต้องการอัปเดต ให้คลิก **Update** แทน  

แพ็กเกจจะดาวน์โหลดและอ้างอิงในโครงการของคุณ  

### **วิธีที่ 2: ติดตั้งหรืออัปเดต Aspose.Slides ผ่าน Package Manager Console**

1. เปิด Microsoft Visual Studio  
2. สร้างโครงการ C++ **Console App** หรือเปิดโครงการที่มีอยู่  
3. ไปที่ **Tools** > **NuGet Package Manager** > **Package Manager Console**  
![Opening the Package Manager Console](installation_2.png)  
4. รันคำสั่งต่อไปนี้:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   สำหรับการสร้าง 32‑บิต (Win32) ให้ติดตั้งแพ็กเกจ x86 แทน:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

![Running the Install-Package command](installation_3.png)

เมื่อติดตั้งเสร็จ จะมีข้อความยืนยัน ปackage นี้อยู่ภายใต้ [Aspose EULA](https://about.aspose.com/legal/eula)  
![Installation confirmation messages](installation_4.png)

เพื่ออัปเดตแพ็กเกจ ให้รัน `Update-Package Aspose.Slides.Cpp` (หรือ `Update-Package Aspose.Slides.Cpp.x86`) ใน Package Manager Console  

### **ตรวจสอบการติดตั้ง**

1. แทนที่เนื้อหาของไฟล์ *.cpp* หลักของโครงการ (ไฟล์ที่มี `main`) ด้วยตัวอย่างแรกใน [Create Presentations](/slides/th/cpp/create-presentation/)  
2. ในแถบเครื่องมือเลือกแพลตฟอร์ม **x64** หรือ **x86** หากคุณได้ติดตั้ง Aspose.Slides.Cpp.x86  
3. กด **Ctrl+F5** เพื่อสร้างและรันโปรแกรม  

โปรแกรมจะบันทึกไฟล์ *hello.pptx* ในโฟลเดอร์ของโครงการ ซึ่งเป็นโฟลเดอร์ทำงานเริ่มต้นเมื่อ Visual Studio รันโปรแกรม  

## **Linux**

บน Linux ใช้แพ็กเกจ ZIP สำหรับ Linux พร้อม CMake แพ็กเกจมีไลบรารี Aspose.Slides, Dependency CodePorting.Translator.Cs2Cpp.Framework และไฟล์กำหนดค่า CMake สำหรับแต่ละส่วน ไลบรารีสร้างสำหรับ Linux x86_64 พร้อม glibc 2.23 หรือใหม่กว่า  

1. ติดตั้งคอมไพเลอร์ C++, make, CMake, unzip และไลบรารี fontconfig ซึ่งเป็น Dependency ของไลบรารี Aspose.Slides บน Debian และ Ubuntu:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. สร้างโฟลเดอร์โครงการและเข้าสู่โฟลเดอร์นั้น:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. ดาวน์โหลดแพ็กเกจ ZIP สำหรับ Linux (**Aspose.Slides for C++ Linux**) จาก [หน้าดาวน์โหลด](https://releases.aspose.com/slides/cpp/) ไปยังโฟลเดอร์โครงการ แล้วแตกไฟล์ลงในโฟลเดอร์ย่อย *aspose-slides-cpp*:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. สร้างไฟล์ชื่อ *CMakeLists.txt* ในโฟลเดอร์โครงการด้วยเนื้อหานี้:

   ```cmake
   cmake_minimum_required(VERSION 3.13)
   project(HelloSlides CXX)

   set(CMAKE_CXX_STANDARD 14)
   set(CMAKE_CXX_STANDARD_REQUIRED ON)

   set(ASPOSE_SLIDES_DIR "${CMAKE_CURRENT_SOURCE_DIR}/aspose-slides-cpp")
   find_package(CodePorting.Translator.Cs2Cpp.Framework REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)
   find_package(Aspose.Slides.Cpp REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)

   add_executable(hello main.cpp)
   target_link_libraries(hello PRIVATE Aspose.Slides.Cpp)
   ```

   คำสั่ง `find_package` สองตัวนี้จะโหลดไฟล์กำหนดค่า CMake จากแพ็กเกจที่แตกไว้ โดย framework จะถูกค้นหาก่อนเพราะ Aspose.Slides พึ่งพา framework การลิงก์ target `Aspose.Slides.Cpp` จะเพิ่มโฟลเดอร์ include และไลบรารีทั้งสองเข้าไปในการสร้าง  

5. บันทึกตัวอย่างแรกใน [Create Presentations](/slides/th/cpp/create-presentation/) เป็นไฟล์ *main.cpp* ในโฟลเดอร์โครงการ  
6. สร้างและรันโปรแกรม:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

โปรแกรมจะบันทึกไฟล์ *hello.pptx* ในโฟลเดอร์ปัจจุบัน CMake จะบันทึกตำแหน่งของไลบรารีไว้ในโปรแกรม ดังนั้นคุณไม่จำเป็นต้องตั้งค่า `LD_LIBRARY_PATH` ตราบใดที่โฟลเดอร์ *aspose-slides-cpp* อยู่ในที่เดิม  

ฟอนต์ที่ใช้ในงานนำเสนอของคุณ หรือฟอนต์ทดแทนที่เหมาะสม ต้องติดตั้งในระบบเพื่อให้ข้อความแสดงผลอย่างถูกต้องเมื่อแปลงสไลด์เป็น PDF หรือรูปภาพ  

## **FAQ**

**มีเวอร์ชันฟรีหรือข้อจำกัดของรุ่นทดลองหรือไม่?**

มีค่ะ หากไม่ได้รับใบอนุญาต Aspose.Slides จะทำงานในโหมดทดลอง: จะมีลายน้ำ “Evaluation” ปรากฏบนทุกสไลด์ที่บันทึกและตัดข้อความบางส่วนจากงานนำเสนอ เพื่อเอาข้อจำกัดเหล่านี้ออก ให้ใช้ [license](/slides/th/cpp/licensing/) ที่ถูกต้อง  

**ทำไมคอมไพเลอร์ถึงรายงานว่าไม่สามารถเปิดไฟล์ *DOM/Presentation.h* ได้?**

แพ็กเกจที่ติดตั้งไม่ตรงกับแพลตฟอร์มที่คุณสร้าง Aspose.Slides.Cpp ใช้ได้เฉพาะการสร้าง x64 ส่วน Aspose.Slides.Cpp.x86 ใช้ได้เฉพาะการสร้าง Win32 ให้เลือกแพลตฟอร์มที่ตรงกันใน Visual Studio หรือให้ติดตั้งแพ็กเกจที่เหมาะกับแพลตฟอร์มของคุณ  