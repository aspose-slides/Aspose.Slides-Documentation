---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /tr/php-java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 
PresentationML, sunum belgeleri için XML tabanlı bir format ailesinin adıdır. Office OpenXML (OOXML), Microsoft Office 2007 uygulamalarında tanıtılan XML tabanlı formattır. Office OpenXML, birkaç özel XML tabanlı işaretleme dili için bir kapsayıcı formattır. PresentationML, Microsoft Office PowerPoint 2007 tarafından belgeleri depolamak için kullanılan işaretleme dilidir.
{{% /alert %}} 

## **PresentationML, Aspose.Slides for PHP via Java içinde**
OOXML PresentationML belgeleri PPTX dosyaları olarak gelir; [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) spesifikasyonuna uyan sıkıştırılmış XML paketleridir. Aspose.Slides for PHP via Java, PresentationML belgelerini oluşturma, okuma, değiştirme ve yazma konusunda kapsamlı destek sağlar. Ayrıca, Aspose.Slides for PHP via Java, PresentationML belgelerini yaygın olarak kullanılan PDF gibi bir belge formatına dışa aktarabilir. Bu, Aspose.Slides for PHP via Java'ın sunum belgelerini kapsamlı bir şekilde ele alması ve PresentationML'in temelde belge içi sunumu sıkıştırılmış bir XML paketi olarak tutması amacıyla tasarlanmış olmasından kaynaklanır.

**Aspose.Slides for PHP via Java tarafından oluşturulan ve Microsoft PowerPoint'te açılan bir PPTX belgesi**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Aspose.Slides for PHP via Java tarafından oluşturulan aynı PPTX belgesinin ZIP içinde görüntülenmesi**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML açık, Aspose.Slides for PHP via Java neden kullanılmalı?**
PresentationML XML tabanlı olduğu için, üçüncü taraf bir sınıf kütüphanesi olan Aspose.Slides for PHP via Java gibi bir çözüme güvenmeden XML sınıflarıyla PresentationML belgelerini işlemek ve oluşturmak mümkündür. Ancak, PresentationML belgeleriyle çalışırken XML sınıflarına göre Aspose.Slides for PHP via Java kullanmanın birkaç avantajı vardır.

OOXML spesifikasyonu birkaç bin sayfa uzunluğundadır; bu nedenle PresentationML belgelerini doğru şekilde ele almak için formatı anlamak adına çok zaman ve çaba harcamanız gerekir. Diğer yandan, Aspose.Slides for PHP via Java ile yalnızca sınıfları, metodları ve özellikleri kullanarak, XML sınıflarıyla yapıldığında karmaşık görünen işlemleri gerçekleştirirsiniz.

Aspose.Slides'in sunduğu bazı özellikler, XML sınıflarıyla PresentationML belgeleri üzerinde çalışırken hiç mevcut değildir:

- PPT belgelerini PDF formatına dışa aktar.
- Bir slaytı Java Framework'ünün desteklediği herhangi bir resim formatına render et.
- Klonlama özelliğini kullanarak kaynak sunumlardan otomatik olarak master kopyala.
- Şekillere koruma uygula.

Aşağıda tek bir slayt ve içinde “Hello World” metni bulunan bir metin kutusu içeren bir PresentationML belgesi örneği verilmiştir. Bu metni XML sınıflarıyla okumak için aşağıdaki parçacığı ayrıştıran bir program yazmanız gerekir. Aspose.Slides bunu sizin için yapar.

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
```php
```