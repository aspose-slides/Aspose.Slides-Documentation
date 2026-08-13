---
title: ใบอนุญาต
type: docs
weight: 50
url: /th/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides สำหรับ JasperReports มีให้ดาวน์โหลดในรูปแบบการประเมินฟรีแบบไม่จำกัดเวลา จาก [หน้า ดาวน์โหลด](https://downloads.aspose.com/slides/th/jasperreport). รุ่นการประเมินและรุ่นที่มีลิขสิทธิ์ของผลิตภัณฑ์ใช้การดาวน์โหลดเดียวกัน.

เมื่อคุณพอใจกับการประเมินแล้ว, [ซื้อไลเซนส์](https://purchase.aspose.com/buy). ตรวจสอบให้แน่ใจว่าคุณเข้าใจและยอมรับเงื่อนไขการสมัครสมาชิก.

ไลเซนส์สามารถดาวน์โหลดได้จากหน้าสั่งซื้อหลังจากการชำระเงินเสร็จสิ้น. ไอเท็มไลเซนส์เป็นไฟล์ XML แบบข้อความเปิดที่ลงลายเซ็นดิจิทัล ซึ่งประกอบด้วยข้อมูลเช่น ชื่อผู้ใช้, ผลิตภัณฑ์ที่ซื้อและประเภทของไลเซนส์. อย่าแก้ไขเนื้อหาของไฟล์ไลเซนส์ในทางใดทางหนึ่ง: การทำเช่นนั้นจะทำให้ไลเซนส์ไม่ถูกต้อง.

ดาวน์โหลดไลเซนส์ไปยังคอมพิวเตอร์ของคุณและคัดลอกไปยังโฟลเดอร์ที่เหมาะสม (เช่น โฟลเดอร์แอปพลิเคชันของคุณหรือ **JasperReports\lib**).
{{% /alert %}}

## **ข้อจำกัดของรุ่นประเมิน**
รุ่นประเมินของ Aspose.Slides (โดยไม่ได้กำหนดไลเซนส์) ให้ฟังก์ชันผลิตภัณฑ์เต็มรูปแบบ, แต่ (เมื่อคุณบันทึกงานนำเสนอ) มันจะใส่น้ำหนักประเมินที่ตำแหน่งกึ่งกลางของแต่ละสไลด์ตามที่แสดงในรูปด้านล่าง:

![todo:image_alt_text](evaluation_watermark.png) 

## **การใช้ไลเซนส์**
มีหลายวิธีในการใช้ไลเซนส์, ขึ้นอยู่กับว่าคุณทำงานบน JasperReports หรือ JasperServer.

### **การใช้ไลเซนส์สำหรับ JasperReports**
ใช้การเรียกเมธอด setLicense โดยตรงเช่นเดียวกับ Aspose.Slides สำหรับ Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //สร้างอ็อบเจ็กต์สตรีมที่ประกอบด้วยไฟล์ไลเซนส์
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //สร้างอินสแตนซ์ของคลาส License
    License license = new License();
	
    //ตั้งค่าไลเซนส์ผ่านอ็อบเจ็กต์สตรีม
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

หรือกำหนดพารามิเตอร์ exporter ในโค้ด.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **การใช้ไลเซนส์บน JasperServer**
กำหนดพารามิเตอร์ exporter ในไฟล์ applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```