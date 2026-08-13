---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /ru/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 

PresentationML — это название семейства форматов на основе XML для презентационных документов. Office OpenXML (OOXML) — XML‑ориентированный формат, представленный в приложениях Microsoft Office 2007. Office OpenXML является контейнерным форматом для нескольких специализированных языков разметки на основе XML. PresentationML — язык разметки, используемый Microsoft Office PowerPoint 2007 для хранения документов.

{{% /alert %}} 

## **PresentationML в Aspose.Slides for Java**
Документы OOXML PresentationML представлены в виде файлов PPTX — упакованных XML‑пакетов, которые соответствуют спецификации [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides for Java широко поддерживает создание, чтение, манипулирование и запись документов PresentationML. Кроме того, Aspose.Slides for Java может экспортировать документы PresentationML в широко используемый формат, например PDF. Это возможно, потому что Aspose.Slides for Java разработан с целью всесторонней работы с презентационными документами, а PresentationML по сути представляет внутреннюю структуру документов как упакованный XML‑пакет.

**Документ PPTX, сгенерированный Aspose.Slides for Java и открытый в Microsoft PowerPoint** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Просмотр того же документа PPTX, сгенерированного Aspose.Slides for Java, в виде ZIP** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML открытый, почему стоит использовать Aspose.Slides for Java?**
Поскольку PresentationML основан на XML, вполне возможно создавать приложения для обработки и генерации документов PresentationML, используя XML‑классы без привлечения сторонних библиотек, таких как Aspose.Slides for Java. Тем не менее, использование Aspose.Slides for Java имеет несколько преимуществ перед XML‑классами при работе с документами PresentationML.

Спецификация OOXML насчитывает несколько тысяч страниц, поэтому для корректной работы с документами PresentationML требуется потратить много времени и усилий на изучение формата. С Aspose.Slides for Java вы просто используете классы, их методы и свойства для выполнения операций, которые выглядят сложными при работе через XML‑классы.

Некоторые возможности, которые предлагает Aspose.Slides, недоступны при работе с документами PresentationML через XML‑классы:

- Экспортировать PPT‑документы в формат PDF.
- Отображать слайд в любой графический формат, поддерживаемый Java Framework.
- Автоматически копировать шаблоны из исходных презентаций с помощью функции клонирования.
- Применять защиту к объектам.

Ниже приводится пример документа PresentationML с одним слайдом, содержащим текстовое поле с текстом «Hello World». Чтобы прочитать текст с помощью XML‑классов, необходимо написать программу, которая сможет разобрать этот простой текст из следующего фрагмента. Aspose.Slides делает это за вас.

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