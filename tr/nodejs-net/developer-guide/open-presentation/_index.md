---
title: Node.js üzerinden .NET ile Sunumları Aç
linktitle: Sunumu Aç
type: docs
weight: 20
url: /tr/nodejs-net/open-presentation/
keywords:
- sunumu aç
- PowerPoint aç
- PPTX aç
- PPT aç
- ODP aç
- sunumu yükle
- buffer'dan sunum
- slayt sayısı
- sunumu dönüştür
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET ile JavaScript'te PPTX, PPT ve ODP sunumlarını açın: bir dosya yolundan veya Buffer'dan yükleyin, slayt sayısını okuyun ve başka bir formatta kaydedin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via .NET, PowerPoint ve OpenDocument sunumlarını, PPTX, PPT ve ODP dosyaları gibi, bir dosya yolundan veya bir Node.js `Buffer`'ından açar. Bu makale her iki yöntemi gösterir, slayt sayısını okur ve açılan bir sunumu başka bir formatta kaydeder.

Örnekler, [Installation](/slides/tr/nodejs-net/installation/) bölümünde ayarladığınız proje klasöründe `sample.pptx` adlı bir sunum bekler. Herhangi bir PowerPoint sunumu uygundur. Her örneği proje klasöründe bir `.js` dosyası olarak kaydedin ve o klasörden `node` ile çalıştırın.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET'in kendi API referansı yoktur. Aspose.Slides for .NET API'sini camelCase adlarıyla yansıttığından, bu makaledeki API bağlantıları [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/tr/net/) içindeki eşleşen sınıflara ve üyelere yönlendirir.
{{% /alert %}}

## **Bir Dosyadan Sunum Açma**

Bir sunumu açmak için, yolunu [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/presentation/) yapıcısına geçirin. Aspose.Slides formatı uzantıdan ziyade dosya içeriğinden algılar, bu yüzden aynı kod PPTX, PPT ve ODP dosyalarını açar. Göreceli bir yol, betiği çalıştırdığınızda proje klasörü olan geçerli çalışma dizinine göre çözülür.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Betik, `sample.pptx` içindeki slayt sayısını, örneğin `Slide count: 9` olarak yazdırır. [slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slides/tr/) koleksiyonunun `count` özelliği gizli slaytları da içerir. Gösterildiği gibi bir `finally` bloğunda `dispose` çağırın, böylece sunumun arkasındaki .NET kaynakları, kodunuz başarısız olsa bile serbest bırakılır.

## **Buffer'dan Sunum Açma**

Bir sunum bir veritabanı, HTTP yüklemesi veya dosya yolu yerine baytlar veren başka bir kaynaktan geldiğinde, ikinci yapıcı argümanı olarak bir Node.js `Buffer` ve ilk argüman olarak `null` geçirin. Aşağıdaki örnek, bu tür bir kaynağı temsil etmek için `sample.pptx` dosyasını bir buffer'a okur:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Betik, önceki örnek ile aynı slayt sayısını yazdırır. İkinci argüman bir `Buffer` olmalıdır. `Uint8Array` gibi başka bir tür için, yapıcı bir hata raporlamaz; bunun yerine bir boş slayt içeren yeni bir sunum oluşturur. Diğer ikili türleri önce `Buffer.from` ile dönüştürün.

## **Sunumu Başka Bir Formatta Kaydet**

Bir sunumu başka bir sunum formatına dönüştürmek için, açın ve farklı bir [SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) değeriyle kaydedin. Aşağıdaki örnek, Aspose.Slides'in algıladığı formatı ve [sourceFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/sourceformat/) özelliğinin döndürdüğü değeri yazdırır ve sunumu bir OpenDocument sunumu olarak kaydeder:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

Betik `Source format: Pptx` yazdırır ve aynı slaytları içeren `sample.odp` dosyasını yazar. `sourceFormat` `Ppt`, `Pptx` veya `Odp` döndürür. Bunun yerine PDF ya da görüntü olarak kaydetmek için [Convert PowerPoint to PDF](/slides/tr/nodejs-net/convert-powerpoint-to-pdf/) ve [Convert Slides to Images](/slides/tr/nodejs-net/convert-slide/) bölümlerine bakın.

## **SSS**

**Şifre korumalı bir sunumu nasıl açarım?**

Bir [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) nesnesi oluşturun, onun [password](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/password/) özelliğini ayarlayın ve nesneyi üçüncü yapıcı argümanı olarak geçirin: `new Presentation("protected.pptx", null, loadOptions)`. Doğru şifre olmadan, yapıcı bir hata fırlatır.

**Neden yapıcı boş bir mesajla `Error` fırlatır?**

`Presentation` yapıcısı .NET'te başarısız olduğunda, örneğin dosya eksik olduğunda, bir sunum olmadığında ya da farklı bir şifre gerektiğinde, JavaScript boş bir mesaj içeren bir `Error` alır. Bir dosya açmadan önce, dosyanın çalışma dizinine göre varlığını, örneğin `fs.existsSync` ile kontrol edin.

**Hangi formatları açabilirim?**

PowerPoint ve OpenDocument sunum formatları, PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP ve FODP dahil.