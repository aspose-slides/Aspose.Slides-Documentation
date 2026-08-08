---
title: การให้ใบอนุญาต
type: docs
weight: 50
url: /th/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports มีให้ใช้งานเป็นการประเมินฟรีไม่จำกัดเวลา จาก [download page](https://downloads.aspose.com/slides/th/jasperreport) รุ่นประเมินและรุ่นที่มีลิขสิทธิ์ใช้ไฟล์ดาวน์โหลดเดียวกัน

เมื่อคุณพอใจกับการประเมินแล้ว [buy a license](https://purchase.aspose.com/buy) โปรดตรวจสอบและยอมรับเงื่อนไขการสมัครสมาชิก

ใบอนุญาตสามารถดาวน์โหลดได้จากหน้าหลังการสั่งซื้อเมื่อการสั่งซื้อได้รับการชำระเงินแล้ว ใบอนุญาตเป็นไฟล์ XML ที่เป็นข้อความธรรมดา ลงลายเซ็นดิจิทัล ซึ่งบรรจุข้อมูลเช่น ชื่อลูกค้า ผลิตภัณฑ์ที่ซื้อและประเภทของใบอนุญาต อย่าแก้ไขเนื้อหาในไฟล์ใบอนุญาตใด ๆ เพราะจะทำให้ใบอนุญาตไม่ถูกต้อง

ดาวน์โหลดใบอนุญาตไปยังคอมพิวเตอร์ของคุณและคัดลอกไปยังโฟลเดอร์ที่เหมาะสม (เช่น โฟลเดอร์แอปพลิเคชันของคุณหรือ **JasperReports\lib**)
{{% /alert %}}

## **Evaluation Version Limitation**
รุ่นประเมินของ Aspose.Slides (โดยไม่ได้ระบุใบอนุญาต) ให้ความสามารถของผลิตภัณฑ์เต็มรูปแบบ แต่เมื่อคุณบันทึกพรีเซนเทชัน จะมีลายน้ำการประเมินแทรกที่กลางสไลด์แต่ละสไลด์ตามที่แสดงในรูปด้านล่าง:

![todo:image_alt_text](evaluation_watermark.png) 

## **Applying a License**
มีหลายวิธีในการใช้ใบอนุญาต ขึ้นอยู่กับว่าคุณทำงานบน JasperReports หรือ JasperServer

### **Applying a License for JasperReports**
ใช้การเรียกเมธอด setLicense โดยตรงเช่นเดียวกับ Aspose.Slides for Java

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //สร้างอ็อบเจ็กต์สตรีมที่บรรจุไฟล์ใบอนุญาต
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //สร้างอินสแตนซ์ของคลาส License
    License license = new License();
	
    //ตั้งค่าใบอนุญาตผ่านอ็อบเจ็กต์สตรีม
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

หรือ ตั้งค่าพารามิเตอร์ exporter ในโค้ด

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Applying a License on JasperServer**
ตั้งค่าพารามิเตอร์ exporter ในไฟล์ applicationContext.xml

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```