---
title: Лицензирование
type: docs
weight: 50
url: /ru/jasperreports/licensing/
description: "Узнайте, что версия оценки Aspose.Slides for JasperReports добавляет в экспортированные файлы и как применить лицензию в JasperReports и JasperReports Server."
---
{{% alert color="info" title="Примечание" %}}

Aspose.Slides for JasperReports доступен в виде бесплатной, неограниченной по времени оценки со [страницы загрузки](https://releases.aspose.com/slides/jasperreport/). Оценочная и лицензированная версии продукта предоставляются из одной и той же загрузки.

Если вы удовлетворены оценкой, [приобретите лицензию](https://purchase.aspose.com/pricing/slides/jasperreports/). Убедитесь, что вы понимаете и соглашаетесь с условиями подписки.

Лицензия становится доступной для скачивания со страницы заказа после оплаты заказа. Лицензия представляет собой обычный текстовый, цифрово подписанный XML-файл, содержащий такие данные, как имя клиента, приобретённый продукт и тип лицензии. Не изменяйте содержимое файла лицензии никоим образом: это делает лицензию недействительной.

Скачайте лицензию на свой компьютер и скопируйте её в соответствующую папку (например, в папку вашего приложения или **JasperReports\lib**).
{{% /alert %}}

## **Ограничения версии оценки**
Оценочная версия Aspose.Slides for JasperReports (без указанной лицензии) экспортирует каждую страницу отчёта, однако добавляет оценочный водяной знак в центр каждого слайда или страницы во всех четырёх выходных форматах (PPT, PPTX, PDF и HTML), как показано на рисунке ниже. Подробнее см. [Оценить Aspose.Slides](/slides/ru/jasperreports/evaluate-aspose-slides/).

![Водяной знак оценки в центре экспортированного слайда](evaluation_watermark.png)

## **Применение лицензии**
Существует несколько способов применения лицензии, в зависимости от того, работаете ли вы с JasperReports или JasperServer.

### **Применение лицензии для JasperReports**
Вызовите метод `setLicense` класса `License`, передав поток, читающий файл лицензии, как в Aspose.Slides for Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Создайте объект потока, содержащий файл лицензии.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Создайте экземпляр класса License.
            License license = new License();

            // Установите лицензию через объект потока.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Либо передайте путь к файлу лицензии экспортеру в параметр `ASExporterParameters.PPT_LICENSE`. В этом фрагменте `jasperPrint` представляет собой заполненный отчёт, как в [Ваш первый экспорт](/slides/ru/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Применение лицензии на JasperServer**
Установите свойство `licenseFile` бина `pptExportParameters` в *applicationContext.xml* в путь к файлу лицензии, как показано в [Интеграции с JasperServer](/slides/ru/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).