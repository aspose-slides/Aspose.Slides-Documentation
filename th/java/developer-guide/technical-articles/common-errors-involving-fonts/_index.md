---
title: ข้อยกเว้นและข้อผิดพลาดที่เกี่ยวข้องกับฟอนต์บน Linux
type: docs
weight: 200
url: /th/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "ข้อยกเว้นฟอนต์, ข้อผิดพลาดฟอนต์, Linux, Java, Aspose.Slides for Java"
description: "ข้อยกเว้นและข้อผิดพลาดของฟอนต์บน Linux"
---
## **ภาพรวม**

เมื่อใช้ Aspose.Slides บน Linux อาจเกิดปัญหาเกี่ยวกับฟอนต์ได้ หากกระบวนการ Java ไม่สามารถเข้าถึงโฟลเดอร์ฟอนต์ที่จำเป็นหรือไดเรกทอรีชั่วคราว, หากระบบไม่มีฟอนต์ติดตั้ง, หรือหากไลบรารีระบบที่จำเป็นเช่น fontconfig หรือ libfreetype ขาดหายไป

บทความนี้อธิบายข้อผิดพลาดและข้อยกเว้นทั่วไปที่เกี่ยวกับฟอนต์บน Linux และให้วิธีแก้ปัญหาโดยอธิบายวิธีตรวจสอบการเข้าถึงโฟลเดอร์ฟอนต์และไดเรกทอรี TEMP, การติดตั้งฟอนต์และไลบรารีที่จำเป็น, และการใช้ `FontsLoader` เพื่อโหลดฟอนต์โดยไม่ต้องติดตั้งลงระบบโดยรวม

## **ข้อความหรือรูปภาพหาย (EMF หรือ WMF) เมื่อโค้ดทำงานบน Linux**

ปัญหานี้เกิดในระบบที่มีข้อจำกัดในกรณีต่อไปนี้:

1. ไม่มีฟอนต์ติดตั้งหรือโฟลเดอร์ฟอนต์สำหรับกระบวนการ Java ไม่สามารถเข้าถึงได้
2. ไดเรกทอรี TEMP ไม่สามารถเข้าถึงได้

### **วิธีแก้**

ตรวจสอบและยืนยันว่าการเข้าถึงไดเรกทอรี TEMP และโฟลเดอร์ฟอนต์ได้รับการอนุญาตแล้ว  

{{% alert color="warning" %}}

ในบางกรณี คุณอาจไม่สามารถให้สิทธิ์การเข้าถึงโฟลเดอร์ได้เนื่องจากข้อจำกัดของสภาพแวดล้อมหรือแนวนโยบายความปลอดภัย ลองใช้วิธีแก้ต่อไปนี้:  

{{% /alert %}}

**วิธีแก้ชั่วคราว**

ใช้ [FontsLoader](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsLoader) เพื่อโหลดฟอนต์ที่จำเป็นโดยไม่ต้องติดตั้งลงระบบ:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

หากไม่สามารถเข้าถึงไดเรกทอรี TEMP ได้ ให้ใช้โค้ดนี้เพื่อกำหนดไดเรกทอรีอื่นเป็น TEMP สำหรับ Java:
```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **ข้อยกเว้น: InvalidOperationException: Cannot Find Any Fonts Installed on the System**

ข้อยกเว้นนี้เกิดเมื่อ

1) กระบวนการ Java ไม่สามารถเข้าถึงโฟลเดอร์ฟอนต์  
2) ไม่มีฟอนต์ติดตั้ง

### **วิธีแก้**

1. ตรวจสอบและยืนยันว่าการเข้าถึงโฟลเดอร์ฟอนต์สำหรับกระบวนการ Java ได้รับการอนุญาต

2. ติดตั้งฟอนต์บางส่วนหรือใช้ [FontsLoader](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsLoader)

3. ติดตั้งฟอนต์

   * Ubuntu: 

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
     ```

   * CentOS: 

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
     ```

   * ใช้ [FontsLoader](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **ข้อยกเว้น: InternalError: InvocationTargetException**

เมื่อแปลงไฟล์ PPTX เป็น PDF บน Linux การแปลงอาจล้มเหลวด้วย `java.lang.InternalError: java.lang.reflect.InvocationTargetException` หากข้อความข้อผิดพลาดพื้นฐานระบุ `Cannot load from short array because "sun.awt.FontConfiguration.head" is null` แสดงว่าการกำหนดค่าฟอนต์ของ Linux ไม่พร้อมใช้งานหรือแคชยังไม่ได้ถูกสร้าง

### **วิธีแก้**

ติดตั้ง fontconfig และสร้างแคชฟอนต์ใหม่:

```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **ข้อยกเว้น: NoClassDefFoundError: Could Not Initialize Class com.aspose.slides.internal.ey.this**

ข้อยกเว้นนี้เกิดบนระบบ Linux ที่ไม่มี fontconfig และฟอนต์  

### **วิธีแก้**

ติดตั้ง fontconfig:

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

นอกจากนี้บางเวอร์ชันของ open-jdk (เช่น **alpine JDK**) ยัง **ต้องการฟอนต์ที่ติดตั้ง** ด้วย

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **ข้อยกเว้น: UnsatisfiedLinkError: libfreetype.so.6: Cannot Open Shared Object File: No Such File or Directory**

ข้อยกเว้นนี้เกิดบนระบบ Linux ที่ไม่มีไลบรารี libfreetype  

### **วิธีแก้**

ติดตั้ง libfreetype และ fontconfig:

* Ubuntu: 

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS: 

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="เคล็ดลับ" color="info" %}} 

อย่าลืมติดตั้งฟอนต์หรือใช้ FontsLoader

{{% /alert %}}  