---
title: Лицензирование
type: docs
weight: 50
url: /ru/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports доступен в виде бесплатной неограниченной по времени оценки со [download page](https://downloads.aspose.com/slides/ru/jasperreport). Оценочная и лицензированная версии продукта предоставляются из одного и того же загрузочного файла.

Когда вас устроит оценка, [buy a license](https://purchase.aspose.com/buy). Убедитесь, что вы понимаете и соглашаетесь с условиями подписки.

Лицензия доступна для загрузки со страницы заказа после оплаты заказа. Лицензия представляет собой обычный текстовый, цифрово подписанный XML‑файл, содержащий такие сведения, как имя клиента, приобретённый продукт и тип лицензии. Не изменяйте содержимое файла лицензии никаким образом: это сделает лицензию недействительной.

Скачайте лицензию на ваш компьютер и скопируйте её в соответствующую папку (например, в папку вашего приложения или **JasperReports\lib**).
{{% /alert %}}

## **Ограничения версии оценки**
Оценочная версия Aspose.Slides (без указания лицензии) обеспечивает полный набор функций продукта, но (при сохранении ваших презентаций) вставляет оценочный водяной знак в центр каждого слайда, как показано на рисунке ниже:

![todo:image_alt_text](evaluation_watermark.png) 

## **Применение лицензии**
Существует несколько способов применения лицензии, в зависимости от того, работаете ли вы с JasperReports или с JasperServer.

### **Применение лицензии для JasperReports**
Вызовите метод setLicense напрямую, аналогично Aspose.Slides for Java.

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

Либо задайте параметр экспортёра в коде.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Применение лицензии на JasperServer**
Задайте параметр экспортёра в файле applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```