---
title: การติดตั้ง
type: docs
weight: 70
url: /th/php-java/installation/
keywords:
- ติดตั้ง Aspose.Slides
- ดาวน์โหลด Aspose.Slides
- ใช้ Aspose.Slides
- การติดตั้ง Aspose.Slides
- วินโดวส์
- ลินุกซ์
- พาวเวอร์พอยต์
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ติดตั้ง Aspose.Slides สำหรับ PHP ผ่าน Java บน Linux และ Windows: ตั้งค่า PHP, Java, Apache Tomcat, และ PHP/Java Bridge, เพิ่มแพคเกจด้วย Composer, และตรวจสอบการตั้งค่าด้วยสคริปต์สั้น ๆ."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java ทำงานในสองกระบวนการ สคริปต์ PHP ของคุณใช้คลาส PHP ที่ส่งทุกคำเรียกผ่าน PHP/Java Bridge ไปยัง Aspose.Slides ซึ่งทำงานบน Java ภายใน Apache Tomcat บทความนี้อธิบายวิธีตั้งค่าทั้งสองด้าน การติดตั้งแพคเกจด้วย Composer และการเรียกสคริปต์สั้น ๆ เพื่อตรวจสอบการติดตั้ง

## **ข้อกำหนดเบื้องต้น**

- **PHP 7.0 ถึง 8.3** พร้อม `allow_url_include = On` ใน `php.ini` สคริปต์ของคุณจะโหลดไลบรารีไคลเอนต์ของบริดจ์ `Java.inc` จาก Tomcat ผ่าน HTTP บน PHP 8.4 ขึ้นไป `Java.inc` จะหยุดทำงานพร้อมข้อผิดพลาด "end() expects exactly 1 argument" เมื่อส่วนขยาย `xml` ของ PHP ถูกโหลด และในเวอร์ชัน Windows ของ PHP จะโหลดเสมอ
- **[Composer](https://getcomposer.org/)**.
- **Java 8 หรือใหม่กว่า** JRE เพียงอย่างเดียวก็พอ
- **Apache Tomcat 9** PHP/Java Bridge สร้างบน API `javax.servlet` ซึ่ง Tomcat 10 ขึ้นไปไม่ได้ให้บริการแล้ว ดังนั้นบริดจ์จะไม่เริ่มทำงานบนเวอร์ชันนั้น
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1** รุ่นล่าสุด ของมัน เว็บแอปพลิเคชัน `JavaBridge.war` จะทำงานใน Tomcat

บทความนี้รัน Tomcat และสคริปต์ PHP ของคุณบนคอมพิวเตอร์เครื่องเดียว Aspose.Slides เปิดและบันทึกไฟล์ภายใน Tomcat ดังนั้นทุกพาธที่สคริปต์ของคุณส่งให้ต้องเป็นพาธที่ใช้ได้ใน Tomcat

## **การติดตั้งบน Linux**

คำสั่งต่อไปนี้จะติดตั้งทุกอย่างในโฟลเดอร์บ้านของคุณบน Ubuntu 24.04 ในดิสโทรอื่น ๆ ให้ติดตั้งแพคเกจเดียวกันด้วยตัวจัดการแพคเกจของดิสโทรนั้น

1. ติดตั้ง PHP, Composer, Java และเครื่องมือดาวน์โหลด แล้วเปิดใช้งาน `allow_url_include` สำหรับบรรทัดคำสั่ง PHP:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

1. ดาวน์โหลด Apache Tomcat 9 และ PHP/Java Bridge ใส่ไฟล์ `JavaBridge.war` ของบริดจ์ลงในโฟลเดอร์ `webapps` ของ Tomcat แล้วเริ่ม Tomcat Tomcat จะแตกไฟล์ WAR ไปยัง `webapps/JavaBridge` ขณะเริ่มทำงาน:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

1. สร้างโฟลเดอร์โปรเจกต์และติดตั้ง Aspose.Slides for PHP via Java จาก [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

1. หยุด Tomcat คัดลอกไฟล์ JAR ของ Aspose.Slides จากแพคเกจไปยังโฟลเดอร์ `WEB-INF/lib` ของบริดจ์ แทนที่ไฟล์ `Java.inc` ของบริดจ์ด้วยเวอร์ชัน PHP 8 จากแพคเกจ แล้วเริ่ม Tomcat อีกครั้ง:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/th/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/th/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   สำหรับ PHP 7 ให้ข้ามขั้นตอนการเปลี่ยนไฟล์ `Java.inc` Tomcat จะใช้เวลาไม่กี่วินาทีในการเริ่มทำงาน และต้องทำงานตลอดเวลาที่สคริปต์ของคุณใช้ Aspose.Slides

## **การติดตั้งบน Windows**

1. ติดตั้ง [PHP 8.3 for Windows](https://www.php.net/downloads.php?os=windows) และเพิ่มโฟลเดอร์ของมันเข้าไปในตัวแปรสภาพแวดล้อม `PATH` คัดลอก `php.ini-production` ไปเป็น `php.ini` ในโฟลเดอร์เดียวกัน ใน `php.ini` ตั้งค่า `allow_url_include = On` และยกเลิกการคอมเมนต์บรรทัด `extension_dir = "ext"` `extension=openssl` และ `extension=zip` Composer ต้องการ `openssl` เพื่อดาวน์โหลดแพคเกจและ `zip` เพื่อแตกไฟล์ เว้นแต่คุณติดตั้ง 7‑Zip หรือมีคำสั่ง `unzip` อยู่ใน `PATH`
2. ติดตั้ง [Composer](https://getcomposer.org/download/).
3. ติดตั้ง Java และตั้งค่าตัวแปรสภาพแวดล้อม `JAVA_HOME` ให้ชี้ไปที่โฟลเดอร์ของ Java Tomcat จะไม่เริ่มทำงานถ้าไม่มีตัวแปรนี้
4. ใน Command Prompt ดาวน์โหลด Apache Tomcat 9 และ PHP/Java Bridge ใส่ไฟล์ `JavaBridge.war` ของบริดจ์ลงในโฟลเดอร์ `webapps` ของ Tomcat แล้วเริ่ม Tomcat สคริปต์ของ Tomcat จะค้นหา Tomcat ผ่านตัวแปร `CATALINA_HOME` ดังนั้นควรใช้หน้าต่าง Command Prompt เดียวกันสำหรับขั้นตอนต่อไป Tomcat จะแตกไฟล์ WAR ไปยัง `webapps\JavaBridge` ขณะเริ่มทำงาน:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_5.2.1/php-java-bridge_5.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

1. สร้างโฟลเดอร์โปรเจกต์และติดตั้ง Aspose.Slides for PHP via Java จาก [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

1. หยุด Tomcat คัดลอกไฟล์ JAR ของ Aspose.Slides จากแพคเกจไปยังโฟลเดอร์ `WEB-INF\lib` ของบริดจ์ แทนที่ไฟล์ `Java.inc` ของบริดจ์ด้วยเวอร์ชัน PHP 8 จากแพคเกจ แล้วเริ่ม Tomcat อีกครั้ง:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   สำหรับ PHP 7 ให้ข้ามขั้นตอนการเปลี่ยนไฟล์ `Java.inc` Tomcat จะใช้เวลาไม่กี่วินาทีในการเริ่มทำงาน และต้องทำงานตลอดเวลาที่สคริปต์ของคุณใช้ Aspose.Slides

## **ตรวจสอบการติดตั้ง**

บันทึกสคริปต์นี้เป็น *hello.php* ในโฟลเดอร์โปรเจกต์ จะสร้างงานนำเสนอที่มีกล่องข้อความเดียวและบันทึกไว้ใกล้ไฟล์สคริปต์:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/th/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เรียกใช้จากโฟลเดอร์โปรเจกต์:

```bash
php hello.php
```

สคริปต์จะเขียนไฟล์ *hello.pptx* ที่มีสไลด์หนึ่งสไลด์ที่บรรจุกล่องข้อความ หากไม่มีลายเซ็นต์ การใช้งานจะมีลายน้ำการประเมินผล; ดูที่ [Licensing](/slides/th/php-java/licensing/)

สคริปต์รวม `aspose.slides.php` โดยตรง: ตัวโหลดอัตโนมัติของ Composer ไม่สามารถโหลดคลาสเหล่านี้ได้ เพราะทั้งหมดถูกกำหนดไว้ในไฟล์เดียวนี้ นอกจากนี้ยังส่งพาธเต็มไปยัง `save` เนื่องจาก Aspose.Slides ทำงานภายใน Tomcat และจะตีความพาธสัมพันธ์เทียบกับโฟลเดอร์ทำงานของ Tomcat ไม่ใช่ของสคริปต์คุณ

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้อย่างไรว่า Aspose.Slides ถูกรวมเข้าด้วยกันอย่างถูกต้อง?**

เรียกสคริปต์ใน [ตรวจสอบการติดตั้ง](#ตรวจสอบการติดตั้ง) หากมันเขียน *hello.pptx* โดยไม่มีข้อผิดพลาด PHP, PHP/Java Bridge, และ Aspose.Slides จะทำงานร่วมกันได้อย่างถูกต้อง

**ทำไมสคริปต์ของฉันถึงหยุดทำงานด้วยข้อความ "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'"?**

PHP ไม่สามารถโหลด `Java.inc` จาก Tomcat ได้ หากข้อความก่อนหน้านั้นบอกว่า wrapper `http://` ถูกปิดใช้งาน ให้ตั้งค่า `allow_url_include = On` ในไฟล์ `php.ini` ที่บรรทัดคำสั่ง PHP ของคุณโหลด; ใช้ `php --ini` เพื่อตรวจสอบไฟล์ที่ใช้ หากแสดงข้อความ "Connection refused" หมายความว่า Tomcat ยังไม่ได้รัน: ให้เริ่ม Tomcat หรือรอไม่กี่วินาทีจนกว่าจะพร้อม

**ฉันจะจำกัดการใช้หน่วยความจำเมื่อประมวลผลงานนำเสนอขนาดใหญ่ได้อย่างไร?**

เพิ่มขีดจำกัดหน่วยความจำของ JVM เพียงเท่าที่ต้องการและปิดแต่ละอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ในบล็อค `finally` เพื่อปล่อยแคชอย่างทันท่วงที วิธีนี้จะป้องกันข้อผิดพลาด out‑of‑memory และทำให้การใช้หน่วยความจำโดยรวมคาดเดาได้ในระหว่างการประมวลผลแบบแบตช์

**ฉันสามารถยกเว้นฟอร์แมตการส่งออกที่ไม่ต้องการเพื่อทำให้ขนาดไฟล์ JAR สุดท้ายเล็กลงได้หรือไม่?**

รุ่นปัจจุบันของ Aspose.Slides จะจัดจำหน่ายเป็นไลบรารีแบบโมโนลิธิคเดียว จึงไม่สามารถปิดฟีเจอร์ผู้ส่งออกเฉพาะเช่น PDF หรือ SVG ในขั้นตอนการสร้างได้.