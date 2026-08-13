---
title: ข้อยกเว้นและข้อผิดพลาดทั่วไปที่เกี่ยวข้องกับฟอนต์บน Linux
type: docs
weight: 200
url: /th/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "ข้อยกเว้นฟอนต์, ข้อผิดพลาดฟอนต์, Linux, Java, Aspose.Slides for Java"
description: "ข้อยกเว้นและข้อผิดพลาดของฟอนต์บน Linux"
---
## **ภาพรวม**

เมื่อใช้ Aspose.Slides บน Linux ปัญหาเกี่ยวกับฟอนต์อาจเกิดขึ้น หากกระบวนการ Java ไม่สามารถเข้าถึงโฟลเดอร์ฟอนต์หรือไดเรกทอรีชั่วคราวที่จำเป็น, หากไม่มีฟอนต์ติดตั้งบนระบบ, หรือหากไลบรารีระบบที่จำเป็นเช่น fontconfig หรือ libfreetype ขาดหายไป.

บทความนี้อธิบายข้อผิดพลาดและข้อยกเว้นทั่วไปที่เกี่ยวข้องกับฟอนต์บน Linux และให้แนวทางแก้ไขเพื่อแก้ปัญหา โดยอธิบายวิธีตรวจสอบการเข้าถึงไดเรกทอรีฟอนต์และ TEMP, การติดตั้งฟอนต์และไลบรารีที่จำเป็น, และการใช้ `FontsLoader` เพื่อโหลดฟอนต์โดยไม่ต้องติดตั้งบนระบบทั้งหมด.

## **ข้อความหรือภาพที่หายไป (EMF หรือ WMF) เมื่อโค้ดทำงานบน Linux**

ปัญหานี้เกิดขึ้นในระบบที่มีข้อจำกัดในกรณีต่อไปนี้:

1. เมื่อไม่มีฟอนต์ติดตั้งหรือเมื่อโฟลเดอร์ฟอนต์สำหรับกระบวนการ java ไม่สามารถเข้าถึงได้
2. เมื่อไม่สามารถเข้าถึงไดเรกทอรี TEMP ได้.

### **วิธีแก้ปัญหา**

ตรวจสอบและยืนยันว่ามีการให้สิทธิ์เข้าถึงไดเรกทอรี TEMP และโฟลเดอร์ฟอนต์แล้ว. 

{{% alert color="warning" %}}

ในบางกรณี คุณอาจไม่สามารถให้สิทธิ์เข้าถึงโฟลเดอร์ได้เนื่องจากข้อจำกัดที่สภาพแวดล้อมหรือวัฒนธรรมความปลอดภัยกำหนด ลองใช้วิธีแก้ปัญติต่อไปนี้: 

{{% /alert %}}

**วิธีแก้ชั่วคราว**

ใช้ [FontsLoader](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsLoader) เพื่อโหลดฟอนต์ที่จำเป็นโดยไม่ต้องติดตั้ง:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

หากไม่สามารถเข้าถึงไดเรกทอรี TEMP ได้ ให้ใช้โค้ดนี้เพื่อระบุไดเรกทอรีอื่นเป็น TEMP สำหรับ Java:
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

## **ข้อยกเว้น: InvalidOperationException: ไม่พบฟอนต์ที่ติดตั้งบนระบบ**

ข้อยกเว้นนี้เกิดขึ้นเมื่อ

1) กระบวนการ Java ไม่สามารถเข้าถึงโฟลเดอร์ฟอนต์  
2) ไม่มีฟอนต์ใดถูกติดตั้ง.

### **วิธีแก้ปัญหา**

1. ตรวจสอบและยืนยันว่ามีการให้สิทธิ์เข้าถึงโฟลเดอร์ฟอนต์สำหรับกระบวนการ Java แล้ว.

2. ติดตั้งฟอนต์บางส่วนหรือใช้ [FontsLoader](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsLoader).

3. ติดตั้งฟอนต์.

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

   * Using [FontsLoader](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **ข้อยกเว้น: NoClassDefFoundError: ไม่สามารถเริ่มต้นคลาส com.aspose.slides.internal.ey.this**

ข้อยกเว้นนี้เกิดบนระบบ Linux ที่ไม่มี fontconfig และฟอนต์. 

### **วิธีแก้ปัญหา**

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

นอกจากนี้ เวอร์ชัน open-jdk บางรุ่น (เช่น **alpine JDK**) ยัง **ต้องการฟอนต์ที่ติดตั้ง**.

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

## **ข้อยกเว้น: UnsatisfiedLinkError: libfreetype.so.6: ไม่สามารถเปิดไฟล์วัตถุที่แชร์: ไม่มีไฟล์หรือไดเรกทอรีดังกล่าว**

ข้อยกเว้นนี้เกิดบนระบบ Linux ที่ไม่มีไลบรารี libfreetype. 

### **วิธีแก้ปัญหา**

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

{{% alert title="TIP" color="info" %}} 

อย่าลืมติดตั้งฟอนต์หรือใช้ FontsLoader.

{{% /alert %}}