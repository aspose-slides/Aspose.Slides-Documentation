---
title: Farklı Dosya Formatları ve Dönüştürmeler
type: docs
weight: 50
url: /tr/cpp/different-file-formats-and-conversions/
---
## **Microsoft PowerPoint (PPT)**
### **PPT Hakkında**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) Microsoft PowerPoint’un farklı sürümleri tarafından oluşturulabilen, okunabilen, işlenebilen ve yazılabilen sunum belge dosya biçimidir. Bu, Microsoft tarafından geliştirilen sunum belgeleri için ikili bir formattır.
### **C++ için Aspose.Slides içinde PPT**
Aspose.Slides for C++ aşağıda listelenen yazılımlar tarafından oluşturulan PPT dosyalarını okuyabilir.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

Benzer şekilde, Aspose.Slides for C++ tarafından oluşturulan PPT dosyaları da yukarıdaki yazılımlar tarafından okunabilir.
### **PPT için Kapsamlı Destek**
Aspose.Slides for C++ PPT belge dosya biçimiyle ilgili neredeyse tüm özellikleri destekler. Sadece farklı Microsoft PowerPoint sürümlerinin sunduğu temel/ileri özellikleri kapsamakla kalmaz, aynı zamanda Microsoft PowerPoint tarafından bile desteklenmeyen bazı özellikleri de sunar. Aspose.Slides for C++ API kütüphanesini kullanmanın temel avantajı, bu özelliklerin kolayca yönetilebilmesidir.

PPT belge dosyalarının oluşturulması, okunması ve yazılmasıyla ilgili temel görevlerin yanı sıra Aspose.Slides for C++ tarafından sağlanan birkaç özellik şunlardır:

- Diğer MS Office dosya biçimlerini PPT belgelerinde OLE Nesneleri olarak içe aktarma.
- PPT belgelerini PDF, TIFF, XPS formatlarına dışa aktarma.
- PPT belgelerindeki slaytları SVG formatına dışa aktarma.
- Slaytı C++ Framework tarafından desteklenen herhangi bir görüntü formatına işleme.
- PPT belgesindeki slayt boyutlarını ayarlama.
- Şekillerde animasyonları yönetme.
- Slayt gösterilerini yönetme.
- Slaytlardaki metni biçimlendirme.
- PPT belgelerinden metin tarama.
- Slaytlardaki tabloları işleme.
- Kopyalama özelliğiyle ana şablonları otomatik olarak kopyalama.

Aspose.Slides for C++ tarafından oluşturulan bir PPT dosyası ve Microsoft PowerPoint’te açılmış hali
## **PresentationML (PPTX, XML)**
### **PresentationML Hakkında**
PresentationML, sunum belgeleri için XML tabanlı bir format ailesinin adıdır. Office OpenXML (OOXML), Microsoft Office 2007 uygulamalarıyla tanıtılan XML tabanlı formattır. Office OpenXML, birkaç özel XML tabanlı işaretleme dili için bir kapsayıcı formattır. PresentationML, Microsoft Office PowerPoint 2007 tarafından belgelerin depolanması için kullanılan işaretleme dilidir.
### **C++ için Aspose.Slides içinde PresentationML**
OOXML PresentationML belgeleri, [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) spesifikasyonlarına uygun sıkıştırılmış XML paketleri olan PPTX dosyaları şeklinde gelir. Aspose.Slides for C++ PresentationML belgelerinin oluşturulması, okunması, işlenmesi ve yazılmasını kapsamlı bir şekilde destekler. Ayrıca, Aspose.Slides for C++ PDF, TIFF ve XPS gibi yaygın kullanılan belge formatlarına PresentationML belgelerini dışa aktarabilir. Bu, Aspose.Slides for C++’ın sunum belgelerini kapsamlı bir şekilde ele alacak şekilde tasarlanmış olması ve PresentationML’in temelde belgelerin iç sunumunu sıkıştırılmış XML paketi olarak tutmasından kaynaklanmaktadır.

Aspose.Slides for C++ tarafından oluşturulan bir PPTX belgesi ve Microsoft PowerPoint’te açılmış hali

Aspose.Slides for C++ ile oluşturulan PPTX belgesinin Zip Uygulamasıyla görüntülenmesi
### **PresentationML Açık, Neden C++ için Aspose.Slides Kullanmalı?**
PresentationML XML tabanlı olduğundan, üçüncü taraf sınıf kütüphanelerine (ör. Aspose.Slides for C++) güvenmeden XML sınıflarını kullanarak PresentationML belgelerini işlemek ve oluşturmak mümkündür. Ancak, PresentationML belgeleriyle çalışırken XML sınıfları yerine C++ için Aspose.Slides kullanmanın bir dizi avantajı vardır.

OOXML spesifikasyonu birkaç bin sayfaya kadar uzanan çok uzun bir dokümandır. Bu, PresentationML belgelerini doğru şekilde ele almak için formatı anlamak adına çok zaman ve çaba harcamanız gerektiği anlamına gelir. Öte yandan, Aspose.Slides for C++ kullanırken ilgili sınıfları ve bunların yöntemlerini/özelliklerini doğrudan kullanarak, XML sınıflarıyla yapılması karmaşık olabilecek işlemleri kolayca gerçekleştirebilirsiniz.

XML sınıflarıyla PresentationML belgeleriyle çalışırken bile bulunamayan bazı özellikler şunlardır:

- PPT belgelerini PDF, TIFF, XPS formatlarına dışa aktarma
- PPT belgelerindeki slaytları SVG formatına dışa aktarma
- Slaytı C++ Framework tarafından desteklenen herhangi bir görüntü formatına işleme
- Kopyalama özelliğiyle kaynak sunumlardan ana şablonları otomatik olarak kopyalama
- Şekillere koruma uygulama

“Hello World” metnini içeren tek bir metin kutusuna sahip bir PresentationML belgesini ele alalım. Bu metni XML sınıflarıyla okumak için aşağıdaki parçacığı ayrıştırabilen bir program yazmanız gerekir:

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
## **PPT‑den PPTX‑e Dönüştürme**
### **Dönüştürme Hakkında**
Aspose.Slides artık PPT’yi PPTX’ye dönüştürmeyi de destekliyor.
### **Dönüştürmede Desteklenen Özellikler**
Aspose.Slides for C++ PPT belge dosyası formatındaki sunumları PPTX dosya formatındaki sunumlara dönüştürme konusunda kısmi destek sağlar. Bahsedilen sunum dönüştürme özelliği Aspose.Slides for C++’a yeni eklendiği için şu anda sınırlı bir yeteneğe sahiptir ve yalnızca basit sunum biçimleri için çalışır. PPT sunumunu PPTX formatına dönüştürmek için Aspose.Slides for C++ API kütüphanesinin sağladığı temel avantaj, istenen sonuca ulaşmak için API’nin kolay kullanılabilir olmasıdır. Daha fazla ayrıntı için lütfen this[link]() adresindeki kod parçacıkları bölümüne gidin. Aşağıdaki bölüm, PPT formatı sunumları PPTX formatına dönüştürülürken hangi özelliklerin desteklendiğini ve hangi özelliklerin desteklenmediğini açıkça gösterir.
### **Desteklenen Özellikler**
Dönüşüm sırasında aşağıdaki özellikler desteklenir:

- Ana şablonlar, düzenler ve slaytların yapısının dönüştürülmesi
- Ana şablonlar, düzenler ve slaytların yapısının dönüştürülmesi
- Grafiklerin dönüştürülmesi
- Grup şekilleri
- Dikdörtgen ve Elips gibi Auto‑shape’lerin dönüştürülmesi. Ancak Auto‑shape’lerin ayar değerleri yanlış olabilir
- Özel geometriye sahip şekiller. Bazen dönüştürülmeyebilir
- Auto‑shape’ler için doku ve resim dolgu stili. Bazen dönüştürülmeyebilir
- Yer tutucuların dönüştürülmesi
- Metin çerçeveleri ve metin tutucularındaki metnin dönüştürülmesi. Ancak madde işaretleri, hizalama ve sekmeler tam uygulanmamıştır
### **Desteklenmeyen Özellikler**
Dönüşüm sırasında aşağıdaki özellikler desteklenmez:

- Notlu slaytlar; Notlar PPTX’te okunamaz. PPT’de varsa henüz PPTX olarak kaydedilemez* Çizgi ve Çoklu Çizgilerin Dönüştürülmesi
- Çizgi ve dolgu formatları
- Gradient dolgu stilleri
- OLE çerçeveleri, Tablolar, Video ve Ses çerçeveleri vb.
- Animasyon ve diğer slayt gösterisi özellikleri atlanır
  Yeni ya da eksik özellikler, Aspose.Slides for C++’ın gelecek sürümlerinde eklenecektir.

Kaynak PPT Sunumu

Dönüştürülmüş PPTX Sunumu
## **Taşınabilir Belge Formatı (PDF)**
### **PDF Hakkında**
[Portable Document Format](https://en.wikipedia.org/wiki/PDF), Adobe System tarafından farklı organizasyonlar arasında belge değişimi için oluşturulmuş bir dosya formatıdır. Bu formatın amacı, belgelerin içeriğinin, görüntülendiği platforma bağımlı olmadan görsel olarak aynı şekilde temsil edilebilmesini sağlamaktır.
### **C++ için Aspose.Slides içinde PDF**
Aspose.Slides for C++ ile yüklenebilen herhangi bir sunum belgesi, tercihinize bağlı olarak [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) veya [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A) standartlarına uygun PDF belgesine dönüştürülebilir. Aspose.Slides for C++ sunum belgelerini PDF’ye dışa aktarırken, dışa aktarılan PDF belgesinin büyük ölçüde orijinal sunum belgesiyle aynı göründüğünden emin olur. Aspose çözümü, PDF belgelerine dönüştürürken aşağıdaki sunum özelliklerini destekler:

- Görseller, Metin Kutuları ve diğer Şekiller
- Metin ve Biçimlendirme
- Paragraflar ve Biçimlendirme
- Köprüler
- Üstbilgi ve Altbilgi
- Madde işaretleri
- Tablolar

Sunum belgelerini yalnızca Aspose.Slides for C++ bileşeniyle doğrudan PDF belgesine dışa aktarabilirsiniz. Bu amaçla başka bir üçüncü taraf veya Aspose.Pdf bileşenine ihtiyacınız yoktur. Ayrıca, [this topic](/slides/tr/cpp/convert-powerpoint-to-pdf/) adresinde açıklandığı gibi PDF dışa aktarma seçeneklerini farklı biçimlerde özelleştirebilirsiniz.

Aspose.Slides for C++ aracılığıyla PDF belgesine dönüştürülmüş bir Sunum Belgesi
## **XML Parser Specification (XPS)**
### **XPS Hakkında**
[XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification), Microsoft tarafından geliştirilen bir sayfa tanım dili ve sabit belge formatıdır. PDF gibi, XPS de belge bütünlüğünü koruyan ve cihaz bağımsız belge görünümü sağlayan sabit‑düzen bir belge formatıdır.
### **C++ için Aspose.Slides içinde XPS**
Aspose.Slides for C++ tarafından yüklenebilen herhangi bir sunum belgesi XPS formatına dönüştürülebilir. Aspose.Slides for C++ yüksek doğruluklu sayfa yerleşimi ve işleme motorunu kullanarak sabit‑düzen XPS belge formatında çıktı üretir. Aspose.Slides for C++’ın, C++ Framework 3.5 ile paketlenen Windows Presentation Foundation (WPF) sınıflarına bağımlı olmadan doğrudan XPS üretmesi, 3.5 öncesi C++ Framework sürümlerinde çalışan makinelerde XPS belgeleri oluşturabilmesini sağlar. XPS’e dışa aktarma hakkında daha fazla bilgi için [this topic](https://docs.aspose.com/slides/tr/cpp/convert-powerpoint-to-xps/) adresine bakabilirsiniz.

Aspose.Slides for C++ aracılığıyla XPS belgesine dönüştürülmüş bir Sunum Belgesi