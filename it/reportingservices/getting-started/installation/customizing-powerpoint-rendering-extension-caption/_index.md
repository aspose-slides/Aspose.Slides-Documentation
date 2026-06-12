---
title: Personalizzazione della didascalia dell'estensione di rendering PowerPoint
type: docs
weight: 60
url: /it/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 

Questo articolo mostra come personalizzare le didascalie delle opzioni di rendering di Aspose.Slides per Reporting Services. 

{{% /alert %}} 
## **Esempio**
Durante l'installazione di Aspose.Slides per Reporting Services, 4 opzioni di esportazione aggiuntive vengono aggiunte nel menu a discesa delle opzioni di esportazione:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **Come modificare il testo delle didascalie**
Le didascalie predefinite di queste estensioni possono essere modificate sovrascrivendo i nomi predefiniti. Questi passaggi mostrano come cambiare la didascalia da “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ” a “ **PowerPoint 97 – 2003 format(PPT)** ”. 

**Passo 1:** Individuare il file **rsreportserver.config** che di solito si trova in questa directory: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**Passo 2:** Trovare queste righe nel file rsreportserver.config: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**Passo 3:** Sostituire il parametro dell'estensione con questo: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

Le opzioni di esportazione ora appariranno così: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)