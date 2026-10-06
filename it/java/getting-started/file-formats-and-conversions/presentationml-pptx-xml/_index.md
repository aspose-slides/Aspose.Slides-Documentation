---
title: PresentationML (PPTX, XML) (Storico)
type: docs
weight: 20
url: /it/java/presentationml-pptx-xml/
keywords:
- PresentationML
- PPTX
- Office Open XML
- storico
- Java
- Aspose.Slides
description: "Storico: una panoramica più vecchia del formato PresentationML (PPTX) in Aspose.Slides per Java, conservata per i collegamenti esistenti. L'elenco attuale dei formati supportati si trova in Formati di file supportati."
---
{{% alert color="info" title="Nota" %}}

Questa è una pagina storica, conservata per i collegamenti esistenti. Non descrive la versione corrente di Aspose.Slides for Java. Per i formati che Aspose.Slides for Java carica, importa, salva e rende, e per l’API di ciascuno, vedere [Formati di file supportati](/slides/it/java/supported-file-formats/). Per confrontare PPTX con PPT, vedere [Comprendere la differenza: PPT vs PPTX](/slides/it/java/ppt-vs-pptx/).

{{% /alert %}}

{{% alert color="info" title="Nota" %}}

PresentationML è il nome di una famiglia di formati basati su XML per documenti di presentazione. Office OpenXML (OOXML) è il formato basato su XML introdotto nelle applicazioni Microsoft Office 2007. Office OpenXML è un formato contenitore per diversi linguaggi di markup specializzati basati su XML. PresentationML è il linguaggio di markup utilizzato da Microsoft Office PowerPoint 2007 per memorizzare i documenti.

{{% /alert %}}

## **PresentationML in Aspose.Slides for Java**
I documenti OOXML PresentationML sono file PPTX, pacchetti XML compressi che seguono la specifica [OOXML ECMA-376](https://ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for Java supporta ampiamente la creazione, lettura, manipolazione e scrittura di documenti PresentationML. Inoltre, Aspose.Slides for Java è in grado di esportare i documenti PresentationML in formati di documento ampiamente usati come il PDF. Ciò è possibile perché Aspose.Slides for Java è stato progettato con l’obiettivo di gestire in modo completo i documenti di presentazione, e PresentationML contiene essenzialmente la rappresentazione interna dei documenti come pacchetto XML compresso.

**Un documento PPTX generato da Aspose.Slides for Java e aperto in Microsoft PowerPoint**

![Un documento PPTX generato da Aspose.Slides for Java e aperto in Microsoft PowerPoint](presentationml-pptx-xml_1.png)


**Lo stesso documento PPTX visualizzato come pacchetto ZIP**

![Lo stesso documento PPTX visualizzato come pacchetto ZIP](presentationml-pptx-xml_2.jpg)


## **PresentationML è aperto, perché usare Aspose.Slides for Java?**
Poiché PresentationML è basato su XML, è del tutto possibile creare applicazioni per elaborare e generare documenti PresentationML utilizzando classi XML senza dipendere da una libreria di classi di terze parti come Aspose.Slides for Java. Tuttavia, esistono diversi vantaggi nell’utilizzare Aspose.Slides for Java rispetto alle classi XML quando si lavora con documenti PresentationML.

La specifica OOXML conta diverse migliaia di pagine, quindi per gestire correttamente i documenti PresentationML occorre dedicare molto tempo ed effort alla comprensione del formato. D’altro canto, con Aspose.Slides for Java basta usare le classi e i loro metodi e proprietà per eseguire operazioni che sembrerebbero complesse se effettuate tramite classi XML.

Alcune delle funzionalità offerte da Aspose.Slides non sono nemmeno disponibili quando si lavora con documenti PresentationML tramite classi XML:

- Esportare documenti PPT in formato PDF.  
- Renderizzare una diapositiva in qualsiasi formato immagine supportato dal framework Java.  
- Copiare automaticamente i master da una presentazione di origine usando la funzione di clonazione.  
- Applicare protezione alle forme.

Di seguito è riportato un esempio di documento PresentationML con una singola diapositiva contenente una casella di testo con il testo “Hello World”. Per leggere il testo usando classi XML, è necessario scrivere un programma che possa analizzare questo semplice testo dal frammento seguente. Aspose.Slides lo fa per voi.

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