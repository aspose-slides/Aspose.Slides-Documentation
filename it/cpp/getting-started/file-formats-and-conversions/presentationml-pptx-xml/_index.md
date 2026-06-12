---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /it/cpp/presentationml-pptx-xml/
---
## **Informazioni su PresentationML**
PresentationML è il nome di una famiglia di formati basati su XML per documenti di presentazione. Office OpenXML (OOXML) è il formato basato su XML introdotto nelle applicazioni Microsoft Office 2007. Office OpenXML è un formato container per diversi linguaggi di markup XML specializzati. PresentationML è il linguaggio di markup usato da Microsoft Office PowerPoint 2007 per memorizzare i propri documenti. 

## **PresentationML in Aspose.Slides per C++**
I documenti OOXML PresentationML si presentano come file PPTX, pacchetti XML compressi che seguono le specifiche [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides per C++ supporta ampiamente la creazione, lettura, manipolazione e scrittura di documenti PresentationML. Inoltre, Aspose.Slides per C++ è in grado di esportare i documenti PresentationML in diversi formati di documento ampiamente usati, come PDF, TIFF e XPS. Questo è possibile perché Aspose.Slides per C++ è stato progettato con l’obiettivo di gestire in modo completo i documenti di presentazione, e PresentationML conserva la presentazione interna dei documenti come pacchetto XML compresso. 

## **PresentationML è Open, perché usare Aspose.Slides per C++**
Poiché PresentationML è basato su XML, è del tutto possibile creare applicazioni per l’elaborazione e la generazione di documenti PresentationML utilizzando classi XML senza fare affidamento su librerie di classi di terze parti come Aspose.Slides per C++. Tuttavia, vi sono diversi vantaggi nell’utilizzare Aspose.Slides per C++ rispetto alle classi XML quando si lavora con documenti PresentationML. 

La specifica OOXML è estremamente estesa, per migliaia di pagine. Ciò significa che, per gestire correttamente i documenti PresentationML, è necessario investire molto tempo e sforzo per comprendere il formato di tali documenti. D’altro canto, usando Aspose.Slides per C++, basta utilizzare le classi pertinenti e i rispettivi metodi / proprietà per eseguire operazioni che risultano piuttosto complesse se realizzate tramite classi XML. 

Di seguito alcune delle funzionalità che non sono nemmeno disponibili quando si gestiscono documenti PresentationML tramite classi XML: 

- Esportazione di documenti PPT in formati PDF, TIFF, XPS
- Esportazione delle diapositive nei documenti PPT in formati SVG
- Rendering della diapositiva in qualsiasi formato immagine supportato dal Framework C++
- Copia automatica dei master da presentazioni di origine mediante la funzionalità di clonazione
- Applicazione di protezione alle forme

Prendiamo un esempio di documento PresentationML contenente una singola diapositiva con una casella di testo che contiene il testo “Hello World”. Per leggere il testo tramite classi XML, è necessario scrivere un programma che possa analizzare questo semplice testo dal frammento seguente: 
## **Esempio**


``` cpp

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