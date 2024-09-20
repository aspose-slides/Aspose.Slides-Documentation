---  
title: PresentationML (PPTX, XML)  
type: docs  
weight: 20  
url: /cpp/presentationml-pptx-xml/  
---  

## **О PresentationML**  
PresentationML — это название семейства форматов на основе XML для презентационных документов. Office OpenXML (OOXML) — это основанный на XML формат, введенный в приложениях Microsoft Office 2007. Office OpenXML является контейнерным форматом для нескольких специализированных языков разметки на основе XML. PresentationML — это язык разметки, используемый Microsoft Office PowerPoint 2007 для хранения его документов.  
## **PresentationML в Aspose.Slides для C++**  
Документы OOXML PresentationML представляют собой файлы PPTX, которые являются упакованными XML-пакетами, следуя спецификациям [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/). Aspose.Slides для C++ широко поддерживает создание, чтение, манипулирование и запись документов PresentationML. Кроме того, Aspose.Slides для C++ способен экспортировать документы PresentationML в различные широко используемые форматы документов, такие как PDF, TIFF и XPS. Это возможно благодаря тому, что Aspose.Slides для C++ был разработан с целью всесторонней обработки презентационных документов, а PresentationML по сути представляет собой внутреннее представление документов в виде упакованного XML-пакета.  

## **PresentationML открыт, почему стоит использовать Aspose.Slides для C++**  
Поскольку PresentationML основан на XML, довольно возможно создать приложения для обработки и генерации документов PresentationML, используя классы XML, без обращения к сторонним библиотекам классов, таким как Aspose.Slides для C++. Однако есть несколько преимуществ использования Aspose.Slides для C++ по сравнению с классами XML при работе с документами PresentationML.  

Спецификация OOXML слишком длинная — несколько тысяч страниц. Это означает, что для правильной обработки документов PresentationML вам придется потратить много времени и усилий на изучение формата таких документов. С другой стороны, при использовании Aspose.Slides для C++ вам просто нужно использовать соответствующие классы и их методы/свойства для выполнения операций, которые кажутся довольно сложными, если выполнять их через классы XML.  

Вот некоторые функции, которые даже недоступны при работе с документами PresentationML через классы XML:  

- Экспорт документов PPT в форматы PDF, TIFF, XPS  
- Экспорт слайдов в документах PPT в форматы SVG  
- Отображение слайда в любой поддерживаемый формат изображения C++ Framework  
- Автоматическое копирование мастеров из исходных презентаций с использованием функции клонирования  
- Применение защиты к фигурам  

Приведем пример документа PresentationML с одним слайдом, содержащим текстовое поле с текстом «Hello World». Чтобы прочитать текст с помощью классов XML, вам придется написать программу, которая может парсить этот простой текст из следующего фрагмента:  
## **Пример**  

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