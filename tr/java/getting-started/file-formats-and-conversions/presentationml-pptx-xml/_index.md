---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /tr/java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 
PresentationML, sunum belgeleri için XML tabanlı formatlar ailesinin adıdır. Office OpenXML (OOXML), Microsoft Office 2007 uygulamalarında tanıtılan XML tabanlı formattır. Office OpenXML, çeşitli özel XML tabanlı işaretleme dilleri için bir kapsayıcı formattır. PresentationML, Microsoft Office PowerPoint 2007 tarafından belgeleri depolamak için kullanılan işaretleme dilidir.
{{% /alert %}} 

## **Aspose.Slides for Java'da PresentationML**
OOXML PresentationML belgeleri, [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) spesifikasyonuna uyan, PPTX dosyaları olarak gelir; sıkıştırılmış XML paketleridir. Aspose.Slides for Java, PresentationML belgelerini oluşturma, okuma, değiştirme ve yazma konusunda kapsamlı destek sunar. Ayrıca, Aspose.Slides for Java, PresentationML belgelerini PDF gibi yaygın kullanılan bir belge formatına dışa aktarabilir. Bu, Aspose.Slides for Java'nun sunum belgelerini kapsamlı bir şekilde ele alması ve PresentationML'in temel olarak belgelerin iç sunumunu sıkıştırılmış bir XML paketi olarak tutması amacıyla tasarlanmış olmasından mümkündür.

**Aspose.Slides for Java tarafından oluşturulan ve Microsoft PowerPoint'te açılan bir PPTX belgesi** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Aspose.Slides for Java tarafından oluşturulan aynı PPTX belgesinin ZIP içinde görüntülenmesi** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML Açık, Neden Aspose.Slides for Java Kullanmalı?**
PresentationML XML tabanlı olduğundan, Aspose.Slides for Java gibi üçüncü parti sınıf kitaplıklarına güvenmeden XML sınıflarını kullanarak PresentationML belgelerini işlemek ve oluşturmak için uygulamalar geliştirmek oldukça mümkündür. Ancak, PresentationML belgeleriyle çalışırken XML sınıflarına göre Aspose.Slides for Java kullanmanın çeşitli avantajları vardır.

OOXML spesifikasyonu birkaç bin sayfa uzunluğunda olduğundan, PresentationML belgelerini doğru şekilde işlemek için formatı anlamak adına çok zaman ve çaba harcamanız gerekir. Öte yandan, Aspose.Slides for Java ile sınıfları, metodları ve özellikleri kullanarak, XML sınıflarıyla yapıldığında karmaşık görünen işlemleri kolayca gerçekleştirebilirsiniz.

Aspose.Slides'in sunduğu bazı özellikler, PresentationML belgeleriyle XML sınıfları aracılığıyla çalışırken hiç mevcut değildir:

- PDF formatına PPT belgelerini dışa aktar.
- Java Çerçevesi tarafından desteklenen herhangi bir görüntü formatına slaytı render et.
- Klonlama özelliğini kullanarak kaynak sunumlardan masterları otomatik olarak kopyala.
- Şekillere koruma uygula.

Aşağıda, tek bir slayt içeren ve içinde “Hello World” metnini barındıran bir metin kutusu bulunan bir PresentationML belgesi örneği yer almaktadır. XML sınıflarıyla metni okumak için, aşağıdaki parçadan bu basit metni ayrıştırabilen bir program yazmanız gerekir. Aspose.Slides bunu sizin için yapar.

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