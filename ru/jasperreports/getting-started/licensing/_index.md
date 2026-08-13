---
title: Лицензирование
type: docs
weight: 50
url: /ru/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides for JasperReports доступен в виде бесплатной неограниченной по времени оценки со страницы [download page](https://downloads.aspose.com/slides/ru/jasperreport). Оценочная и лицензированная версии продукта распространяются из одного и того же пакета.

Когда вы будете довольны оценкой, [buy a license](https://purchase.aspose.com/buy). Убедитесь, что вы понимаете и соглашаетесь с условиями подписки.

Лицензия доступна для загрузки со страницы заказа после оплаты. Лицензия представляет собой обычный текстовый XML‑файл с цифровой подписью, содержащий такие сведения, как имя клиента, приобретённый продукт и тип лицензии. Не изменяйте содержимое файла лицензии ни в коём случае: это сделает лицензию недействительной.

Скачайте лицензию на ваш компьютер и скопируйте её в соответствующую папку (например, в папку вашего приложения или **JasperReports\lib**).
{{% /alert %}}

## **Ограничения версии оценки**
Оценочная версия Aspose.Slides (без указания лицензии) предоставляет полный функционал продукта, но при сохранении презентаций вставляет оценочный водяной знак в центр каждого слайда, как показано на рисунке ниже:

![todo:image_alt_text](evaluation_watermark.png) 

## **Применение лицензии**
Существует несколько способов применить лицензию, в зависимости от того, работаете ли вы с JasperReports или JasperServer.

### **Применение лицензии для JasperReports**
Вызовите метод setLicense напрямую, аналогично Aspose.Slides for Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //Создать объект потока, содержащий файл лицензии
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //Создать экземпляр класса License
    License license = new License();
	
    //Установить лицензию через объект потока
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Или задайте параметр экспортера в коде.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Применение лицензии на JasperServer**
Установите параметр экспортера в файле applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```