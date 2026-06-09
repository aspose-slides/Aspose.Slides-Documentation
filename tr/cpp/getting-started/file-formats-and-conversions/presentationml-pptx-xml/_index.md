---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /tr/cpp/presentationml-pptx-xml/
---
## **PresentationML Hakkında**
PresentationML, sunum belgeleri için XML tabanlı formatlar ailesinin adıdır. Office OpenXML (OOXML), Microsoft Office 2007 uygulamalarında tanıtılan XML tabanlı formattır. Office OpenXML, çeşitli özelleşmiş XML tabanlı işaretleme dilleri için bir kapsayıcı formattır. PresentationML, Microsoft Office PowerPoint 2007 tarafından belgelerini depolamak için kullanılan işaretleme dilidir.

## **C++ için Aspose.Slides içinde PresentationML**
OOXML PresentationML belgeleri, [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) spec'lerine uyan sıkıştırılmış XML paketleri olan PPTX dosyaları şeklinde gelir. Aspose.Slides for C++ , PresentationML belgelerini oluşturma, okuma, manipülasyon ve yazma konusunda kapsamlı destek sağlar. Ayrıca, Aspose.Slides for C++ , PresentationML belgelerini PDF, TIFF ve XPS gibi yaygın olarak kullanılan farklı belge formatlarına dışa aktarabilir. Bu, Aspose.Slides for C++'ın sunum belgelerini kapsamlı bir şekilde ele almayı hedefleyerek tasarlanmış olmasından ve PresentationML'in temelde belgelerin iç sunumunu sıkıştırılmış XML paketi olarak tutmasından kaynaklanır.

## **PresentationML Açık, Neden C++ için Aspose.Slides Kullanmalı**
PresentationML XML tabanlı olduğundan, Aspose.Slides for C++ gibi üçüncü taraf sınıf kütüphanelerine bağımlı olmadan XML sınıflarını kullanarak PresentationML belgelerini işlemek ve oluşturmak için uygulamalar geliştirmek mümkündür. Ancak, PresentationML belgeleriyle çalışırken XML sınıflarına kıyasla C++ için Aspose.Slides kullanmanın çeşitli avantajları vardır.

OOXML spesifikasyonu birkaç bin sayfaya kadar uzanan çok uzun bir dokümandır. Bu, PresentationML belgelerini doğru bir şekilde işlemek için bu belgelerin formatını anlamak adına çok zaman ve çaba harcamanız gerektiği anlamına gelir. Öte yandan, C++ için Aspose.Slides kullanırken, XML sınıflarıyla gerçekleştirildiğinde oldukça karmaşık görünen işlemleri gerçekleştirmek için ilgili sınıfları ve bunların yöntemlerini/özelliklerini kullanmanız yeterlidir.

Aşağıdakiler, PresentationML belgeleriyle XML sınıfları üzerinden çalışırken bile mevcut olmayan bazı özelliklerdir:
- PPT belgelerini PDF, TIFF, XPS formatlarına dışa aktar
- PPT belgelerindeki slaytları SVG formatına dışa aktar
- Slaytı C++ Framework tarafından desteklenen herhangi bir görüntü formatına render et
- Klonlama özelliği kullanarak kaynak sunumlardan masterların otomatik kopyalanması
- Şekillere koruma uygulama

Tek bir slayt ve içinde “Hello World” metni bulunan bir metin kutusu olan bir PresentationML belgesine örnek verelim. XML sınıfları aracılığıyla metni okumak için aşağıdaki parçadan bu basit metni ayrıştırabilen bir program yazmanız gerekir:

## **Örnek**

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