---
title: Лицензирование
type: docs
weight: 50
url: /ru/jasperreports/licensing/
---

{{% alert color="primary" %}} 

Aspose.Slides для JasperReports доступен как бесплатная версия без ограничения по времени с [страницы загрузки](https://downloads.aspose.com/slides/jasperreport). Версии для оценки и лицензированные версии продукта имеют одну и ту же загрузку.

Когда вы будете довольны оценочной версией, [купите лицензию](https://purchase.aspose.com/buy). Убедитесь, что вы понимаете и соглашаетесь с условиями подписки.

Лицензия доступна для загрузки со страницы заказа после того, как заказ будет оплачен. Лицензия представляет собой файл XML в открытом текстовом формате, подписанный в цифровом виде, который содержит информацию, такую как имя клиента, купленный продукт и тип лицензии. Не изменяйте содержание файла лицензии никаким образом: это делает лицензию недействительной.

Скачайте лицензию на ваш компьютер и скопируйте ее в соответствующую папку (например, вашу папку приложения или **JasperReports\lib**).

## **Ограничения оценочной версии**
Оценочная версия Aspose.Slides (без указанной лицензии) предоставляет полную функциональность продукта, но (когда вы сохраняете свои презентации) вставляет водяной знак оценки в центре каждого слайда, как показано на рисунке ниже:

![todo:image_alt_text](evaluation_watermark.png) 

## **Применение лицензии**
Существует несколько способов применения лицензии, в зависимости от того, работаете ли вы с JasperReports или JasperServer.

### **Применение лицензии для JasperReports**
Используйте прямой вызов метода setLicense, аналогичный Aspose.Slides для Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Создайте объект потока, содержащий файл лицензии
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Создайте экземпляр класса License
    License license = new License();
	
    //Установите лицензию через объект потока
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Или установите параметр экспортера в коде.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Применение лицензии на JasperServer**
Установите параметр экспортера в applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```