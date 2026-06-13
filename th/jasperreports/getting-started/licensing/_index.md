---
title: ใบอนุญาต
type: docs
weight: 50
url: /th/jasperreports/licensing/
---
{{% alert color="primary" %}}

Aspose.Slides สำหรับ JasperReports มีให้ใช้ฟรีแบบประเมินไม่จำกัดเวลา จาก [หน้าดาวน์โหลด](https://downloads.aspose.com/slides/th/jasperreport). รุ่นประเมินและรุ่นที่มีลิขสิทธิ์ของผลิตภัณฑ์ใช้การดาวน์โหลดเดียวกัน.

เมื่อคุณพึงพอใจกับการประเมินแล้ว, [ซื้อใบอนุญาต](https://purchase.aspose.com/buy). โปรดตรวจสอบให้แน่ใจว่าคุณเข้าใจและยอมรับเงื่อนไขการสมัครสมาชิก.

ใบอนุญาตสามารถดาวน์โหลดได้จากหน้าสั่งซื้อหลังจากการสั่งซื้อได้รับการชำระเงินแล้ว. ใบอนุญาตเป็นไฟล์ XML ข้อความธรรมดาที่ลงลายเซ็นดิจิทัล ซึ่งมีข้อมูลเช่น ชื่อลูกค้า, ผลิตภัณฑ์ที่ซื้อและประเภทของใบอนุญาต. อย่าแก้ไขเนื้อหาของไฟล์ใบอนุญาตในทางใดๆ: การทำเช่นนั้นจะทำให้ใบอนุญาตไม่เป็นผล.

ดาวน์โหลดใบอนุญาตไปยังคอมพิวเตอร์ของคุณและคัดลอกไปยังโฟลเดอร์ที่เหมาะสม (เช่น โฟลเดอร์แอปพลิเคชันของคุณหรือ **JasperReports\lib**).

## **ข้อจำกัดของเวอร์ชันประเมิน**
เวอร์ชันประเมินของ Aspose.Slides (โดยไม่มีการระบุใบอนุญาต) ให้ฟังก์ชันการทำงานของผลิตภัณฑ์เต็มรูปแบบ, แต่ (เมื่อคุณบันทึกงานพรีเซนเทชัน) มันจะใส่น้ำตราประเมินที่ศูนย์กลางของแต่ละสไลด์ตามที่แสดงในรูปด้านล่าง:

![todo:image_alt_text](evaluation_watermark.png) 

## **การประยุกต์ใช้ใบอนุญาต**
มีหลายวิธีในการประยุกต์ใช้ใบอนุญาต, ขึ้นอยู่กับว่าคุณกำลังทำงานกับ JasperReports หรือ JasperServer.

### **การประยุกต์ใช้ใบอนุญาตสำหรับ JasperReports**
ใช้การเรียกเมธอด setLicense โดยตรงที่คล้ายกับ Aspose.Slides สำหรับ Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //สร้างอ็อบเจกต์สตรีมที่บรรจุไฟล์ใบอนุญาต
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //สร้างอินสแตนซ์ของคลาส License
    License license = new License();
	
    //กำหนดใบอนุญาตผ่านอ็อบเจกต์สตรีม
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

หรือ, ตั้งค่าพารามิเตอร์ exporter ในโค้ด.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **การประยุกต์ใช้ใบอนุญาตบน JasperServer**
ตั้งค่าพารามิเตอร์ exporter ในไฟล์ applicationContext.xml.

```xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```