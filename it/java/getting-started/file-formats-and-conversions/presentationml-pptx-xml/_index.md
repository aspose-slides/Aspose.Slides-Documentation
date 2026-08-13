---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /it/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 

PresentationML è un nome per una famiglia di formati basati su XML per documenti di presentazione. Office OpenXML (OOXML) è il formato basato su XML introdotto nelle applicazioni Microsoft Office 2007. Office OpenXML è un formato contenitore per diversi linguaggi di markup basati su XML specializzati. PresentationML è il linguaggio di markup utilizzato da Microsoft Office PowerPoint 2007 per memorizzare i documenti.

{{% /alert %}} 

## **PresentationML in Aspose.Slides for Java**
I documenti OOXML PresentationML vengono forniti come file PPTX, pacchetti XML compressi che seguono la specifica [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for Java supporta ampiamente la creazione, lettura, manipolazione e scrittura di documenti PresentationML. Inoltre, Aspose.Slides for Java è in grado di esportare i documenti PresentationML in un formato di documento ampiamente utilizzato come il PDF. Questo è possibile perché Aspose.Slides for Java è stato progettato con l'obiettivo di gestire in modo completo i documenti di presentazione e PresentationML conserva sostanzialmente la presentazione interna dei documenti come un pacchetto XML compresso.

**Un documento PPTX generato da Aspose.Slides for Java e aperto in Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Visualizzazione dello stesso documento PPTX generato da Aspose.Slides for Java in un file ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML è aperto, perché usare Aspose.Slides for Java?**
Poiché PresentationML è basato su XML, è del tutto possibile creare applicazioni per elaborare e generare documenti PresentationML utilizzando classi XML senza fare affidamento su una libreria di classi di terze parti come Aspose.Slides for Java. Tuttavia, esistono diversi vantaggi nell'utilizzare Aspose.Slides for Java rispetto alle classi XML quando si lavora con documenti PresentationML.

La specifica OOXML è lunga diverse migliaia di pagine, quindi per gestire correttamente i documenti PresentationML è necessario spendere molto tempo ed energia per comprendere il formato. D'altro canto, con Aspose.Slides for Java, si utilizzano semplicemente le classi e i loro metodi e proprietà per eseguire operazioni che sembrerebbero complesse se eseguite tramite classi XML.

Alcune delle funzionalità offerte da Aspose.Slides non sono nemmeno disponibili quando si lavora con documenti PresentationML tramite classi XML:

- Esportare documenti PPT in formato PDF.  
- Rendering di una diapositiva in qualsiasi formato immagine supportato dal framework Java.  
- Copiare automaticamente i master da presentazioni di origine usando la funzione di clonazione.  
- Applicare protezione alle forme.

Di seguito è riportato un esempio di documento PresentationML con una singola diapositiva contenente una casella di testo con il testo “Hello World”. Per leggere il testo utilizzando classi XML, è necessario scrivere un programma che possa analizzare questo semplice testo dal frammento seguente. Aspose.Slides lo fa per te.

**XML**

``` xml
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">
  <p:cSld>
    <p:spTree>
      <p:nvGrpSpPr>
        <p:cNvPr id="1" name=""/>
        <p:cNvGrpSpPr/>
        <p:nvPr/>
      </p:nvGrpSpPr>
      <p:grpSpPr>
        <a:xfrm>
          <a:off x="0" y="0"/>
          <a:ext cx="0" cy="0"/>
          <a:chOff x="0" y="0"/>
          <a:chExt cx="0" cy="0"/>
        </a:xfrm></p:grpSpPr><p:sp>
          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>
          <p:cNvSpPr txBox="1"/>
            <p:nvPr/>
          </p:nvSpPr>
          <p:spPr>
            <a:xfrm>
              <a:off x="2819400" y="2590800"/>
              <a:ext cx="1297086" cy="369332"/>
            </a:xfrm>
            <a:prstGeom prst="rect">
              <a:avLst/>
            </a:prstGeom>
            <a:noFill/>
          </p:spPr>
          <p:txBody>
            <a:bodyPr wrap="none" rtlCol="0">
              <a:spAutoFit/>
            </a:bodyPr>
            <a:lstStyle/>
            <a:p>
              <a:r>
                <a:rPr lang="en-US"/>
                <a:t>Hello World
                </a:t>
              </a:r>
              <a:endParaRPr lang="en-US"/>
            </a:p>
          </p:txBody>
        </p:sp>
    </p:spTree>
  </p:cSld>
  <p:clrMapOvr>
    <a:masterClrMapping/>
  </p:clrMapOvr>
</p:sld>
```