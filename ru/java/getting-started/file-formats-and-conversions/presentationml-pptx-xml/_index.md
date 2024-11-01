---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /ru/java/presentationml-pptx-xml/
---

{{% alert color="primary" %}} 

PresentationML — это название для семейства форматов на основе XML для презентационных документов. Office OpenXML (OOXML) — это формат на основе XML, который был введен в приложениях Microsoft Office 2007. Office OpenXML является контейнерным форматом для нескольких специализированных языков разметки на основе XML. PresentationML — это язык разметки, используемый Microsoft Office PowerPoint 2007 для хранения документов.

{{% /alert %}} 

## **PresentationML в Aspose.Slides для Java**
Документы OOXML PresentationML представлены в виде файлов PPTX, упакованных XML-пакетов, которые соответствуют спецификации [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides для Java широко поддерживает создание, чтение, манипулирование и запись документов PresentationML. Кроме того, Aspose.Slides для Java способен экспортировать документы PresentationML в широко используемый формат документов, такой как PDF. Это возможно потому, что Aspose.Slides для Java был разработан с целью всестороннего управления презентационными документами, а PresentationML в основном содержит внутреннее представление документов в виде упакованного XML-пакета.

**Документ PPTX, сгенерированный Aspose.Slides для Java и открытый в Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Просмотр того же документа PPTX, сгенерированного Aspose.Slides для Java, в формате ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML открыт, зачем использовать Aspose.Slides для Java?**
Поскольку PresentationML основан на XML, вполне возможно создавать приложения для обработки и генерации документов PresentationML с использованием XML-классов без обращения к сторонней библиотеке классов, такой как Aspose.Slides для Java. Однако есть несколько преимуществ использования Aspose.Slides для Java по сравнению с XML-классами при работе с документами PresentationML.

Спецификация OOXML насчитывает несколько тысяч страниц, поэтому для правильной обработки документов PresentationML вам потребуется потратить много времени и усилий, чтобы понять формат. С другой стороны, с Aspose.Slides для Java вам просто нужно использовать классы и их методы и свойства для выполнения операций, которые кажутся сложными, если их выполнять через XML-классы.

Некоторые функции, которые предоставляет Aspose.Slides, даже недоступны, когда вы работаете с документами PresentationML через XML-классы:

- Экспорт документов PPT в формат PDF.
- Отрисовка слайда в любой поддерживаемый Java Framework формат изображения.
- Автоматическое копирование мастеров из исходных презентаций с использованием функции клонирования.
- Применение защиты к фигурам.

Ниже приведен пример документа PresentationML с одним слайдом, содержащим текстовое поле с текстом "Hello World". Чтобы прочитать текст с помощью XML-классов, вам нужно написать программу, которая может разобрать этот простой текст из следующего фрагмента. Aspose.Slides делает это за вас.

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