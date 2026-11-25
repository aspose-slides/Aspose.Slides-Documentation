---
title: Node.js'te Uzun Süreli Sunum İşlemlerini Kesintiye Uğratma
linktitle: Sunum İşlemlerini Kesintiye Uğrat
type: docs
weight: 120
url: /tr/nodejs-java/support-for-interruptable-library/
keywords:
- kesintiye uğrayabilir işlemler
- kesinti belirteci
- iptal belirteci
- dönüştürme zaman aşımı
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java içinde uzun süren sunum işlemlerini iptal edin, bir dönüştürme zaman aşımı ayarlayın ve iptal öncesi dışa aktarılan slaytları izleyin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, bir sunumu yüklerken, kaydederken veya oluştururken iptal etmeyi destekler. Aynı token'ı kendi dışa aktarma döngünüzde de kontrol edebilir, bir sonraki slayttan önce durdurabilir ve zaten kaydedilmiş slaytların sayılarını döndürebilirsiniz.

## **Sunum İşlemini Kesintiye Uğratma**

Bir [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/) oluşturun, token'ını [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) ile alın ve onu [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken) metoduna geçirin. Bu seçenekleri [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) oluştururken kullanın. Kaynağın üzerindeki [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) metodunu çağırmak, geçerli işlemin iptalini talep eder. Aspose.Slides, token'ı bir sonraki kontrol ettiğinde durur.

### **Bir Dönüştürme Zaman Aşımını Ayarlama**

Aşağıdaki örnek, `sample.pptx` dosyasını açmak ve `sample.pdf` olarak kaydetmek için 20 saniye izin verir. Yapıcı ve kaydetme işlemleri, Java köprüsü üzerinden eşzamansız olarak çalıştığından Node.js zamanlayıcısı her iki işlem sırasında da tetiklenebilir. Örnek, token'ı yüklemeden sonra ve kaydetmeden sonra tekrar kontrol eder; çünkü bir kütüphane çağrısı iptal isteğinden sonra dönebilir. İşlem tamamlandığında sunumu serbest bırakır ve dönüşüm erken biterse zamanlayıcıyı temizler. Kaydetme sırasında iptal olursa, çıktı dosyası zaten mevcut olabilir ve eksik kalabilir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

10 saniyelik bir sınırlama ile eski PowerPoint formatına dönüştürmek için, son üç argüman olarak `"sample.ppt"`, `slides.SaveFormat.Ppt` ve `10000` değerlerini geçirin.

## **Sonraki Slaytı İşleme Almadan Önce Durdurun**

Çağrı yapan kısmi bir sonuç kullanabiliyorsa, her dışa aktarmadan önce [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) metodunu kullanın. Seçili slaytlar için [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) aşırı yüklemesi, 1'den başlayan slayt numaralarını içeren bir Java `int[]` alır. Her numarayı, PDF'si başarıyla kaydedildikten sonra kaydedin.

`sample.pptx` adlı ve en az iki slayt içeren bir sunumla örneği çalıştırın. Dışa aktarmalar arasında iptali göstermek için, örnek ilk slaytı kaydettikten hemen sonra ister.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

Örnek `slide-1.pdf` oluşturur ve `Starting slide 1` ardından `Completed: [1]` mesajını yazdırır. Döngü, slayt 2'ye başlamadan önce iptali gözlemler. Eğer bir kaydetme işlemi kendisi kesintiye uğrarsa, döndürülen liste yalnızca önceki başarılı dışa aktarmaları içerir.

Çağrı yapanın iptali bir hata olarak ele almasını sağlamak için, döngünün başındaki kontrolü ve `break` ifadesini [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) ile değiştirin; bu, `token.throwIfInterruptionRequested()` şeklinde çağrılır. Aynı kontrolü kaydetmeden sonra da kullanın ve etrafındaki `try`/`catch` bloklarını kaldırın. Aynı girdiyle, ilk PDF yine oluşturulur ve ikinci yineleme, fonksiyon bir liste döndürmeden önce bir istisna fırlatır.

## **SSS**

**İptali Ne Zaman İstemeliyim?**

Bir son tarih geçince veya uygulama sonuca artık ihtiyaç duymadığında iptal isteyin. Yükleme, kaydetme ve oluşturma işlemleri, yapı sırasında sunuma geçirilen token'ı kullanabilir.

**Kaynak ve token nasıl farklıdır?**

Kaynak, uygulamanın iptal istemesine olanak tanır. Token ise Aspose.Slides ve kendi kodunuzun bu isteği kontrol etmesini sağlar.

**Bir Node.js zamanlayıcısı eşzamanlı bir kaydetmeyi kesintiye uğratabilir mi?**

Eşzamanlı bir kaydetme, çağıran iş parçacığındaki JavaScript'i engeller. Zamanlayıcının kaydetme sırasında iptal isteğinde bulunabilmesi için zaman aşımı örneğinde gösterilen eşzamansız Java köprüsü çağrılarını kullanın.

**İptal hemen etkili olur mu?**

İptal iş birliğine dayalıdır. Çalışmakta olan bir işlem, isteği gördüğünde durur. Zaten tamamlanmış bir işlem sonucunu korur.

**Birden çok işlem aynı kaynağı paylaşabilir mi?**

Evet. `interrupt()` çağrısı, o kaynaktan alınan token'ı kullanan tüm işlemler için iptal talep eder. Bağımsız olarak iptal etmek istediğiniz her işlem için ayrı bir kaynak kullanın.