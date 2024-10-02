---
title: Настройка подписи расширения рендеринга PowerPoint
type: docs
weight: 60
url: /ru/reportingservices/customizing-powerpoint-rendering-extension-caption/
---

{{% alert color="primary" %}} 

Эта статья покажет вам, как настроить подписи параметров рендеринга Aspose.Slides для Reporting Services. 

{{% /alert %}} 
## **Пример**
При установке Aspose.Slides для Reporting Services в выпадающем меню параметров экспорта добавляется 4 дополнительных параметра экспорта:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **Как изменить текст подписей**
По умолчанию подписи этих расширений можно изменить, переопределив их имена. Следующие шаги покажут вам, как изменить подпись с “ **PPT – Презентация PowerPoint** **через** **Aspose.Slides** ” на “ **Формат PowerPoint 97 – 2003 (PPT)** ”. 

**Шаг 1:** Найдите файл **rsreportserver.config**, который обычно находится в этой директории: 

**Диск корневой ОС\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Шаг 2:** Найдите эти строки в файле rsreportserver.config: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**Шаг 3:** Замените параметр расширения на следующий: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">Формат PowerPoint 97 - 2003 (PPT)</Name>

        </OverrideNames>

</Extension>



```

Параметры экспорта теперь будут выглядеть так: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)