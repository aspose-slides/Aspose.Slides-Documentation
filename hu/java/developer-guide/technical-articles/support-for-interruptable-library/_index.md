---
title: Megszakítható könyvtár támogatása
type: docs
weight: 120
url: /hu/java/support-for-interruptable-library/
keywords:
- megszakítható könyvtár
- megszakítási token
- visszavonási token
- hosszú futású feladat
- feladat megszakítása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tegye a hosszú futású feladatokat megszakíthatóvá az Aspose.Slides for Java használatával. Biztonságosan szakítsa meg a renderelést és a konverziókat PowerPoint és OpenDocument esetén, példákkal."
---
## **Áttekintés**

Az Aspose.Slides egy megszakítható feldolgozási mechanizmust biztosít a hosszú ideig futó prezentációs feladatokhoz, például a deszerializáláshoz, sorosításhoz és rendereléshez. Ez a mechanizmus a `InterruptionToken` és a `InterruptionTokenSource` osztályokon alapul.

Az `InterruptionToken` hozzárendelhető a `LoadOptions` osztályhoz, és átadható a `Presentation` konstruktorának. Amikor a `InterruptionTokenSource.interrupt()` metódust meghívják, a kapcsolódó hosszú futású feladat megszakad.

## **Megszakítható Könyvtár**

Az [Aspose.Slides 18.4](https://releases.aspose.com/slides/hu/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/) verzióban bevezettük a [InterruptionToken](https://reference.aspose.com/slides/hu/java/com.aspose.slides/interruptiontoken/) és a [InterruptionTokenSource](https://reference.aspose.com/slides/hu/java/com.aspose.slides/interruptiontokensource/) osztályokat. Lehetővé teszik a hosszú futású feladatok, például a deszerializálás, sorosítás és renderelés megszakítását.

- A [InterruptionTokenSource](https://reference.aspose.com/slides/hu/java/com.aspose.slides/interruptiontokensource/) a token(ek) forrása, amely(ek)et a [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) kapja.
- Amikor a [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) be van állítva, és a [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/) példányt átadják a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) konstruktorának, a [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/interruptiontokensource/#interrupt--) meghívása megszakítja az ezzel a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) kapcsolatos bármely hosszú futású feladatot.

Az alábbi kódrészlet bemutatja egy futó feladat megszakítását:

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // a műveletet külön szálon futtatja
Thread.sleep(10000);     // időtúllépés
tokenSource.interrupt(); // a konverzió leállítása
```

## **GYIK**

**Mi a célja az Aspose.Slides megszakítási könyvtárnak?**

Ez egy mechanizmust biztosít a hosszú futású műveletek—például prezentációk betöltése, mentése vagy renderelése—megszakítására, mielőtt befejeződnének. Hasznos, ha a feldolgozási időt korlátozni kell, vagy a feladat már nem szükséges.

**Mi a különbség a [InterruptionToken](https://reference.aspose.com/slides/hu/java/com.aspose.slides/interruptiontoken/) és a [InterruptionTokenSource](https://reference.aspose.com/slides/hu/java/com.aspose.slides/interruptiontokensource/) között?**

- A `InterruptionToken` az Aspose.Slides API felé kerül átadásra, és a hosszú futású műveletek során ellenőrzésre kerül.
- A `InterruptionTokenSource` a kódban a tokenek létrehozására és a megszakítások indítására szolgál a `Interrupt()` hívásával.

**Mely feladatok szakíthatók meg?**

Bármely Aspose.Slides feladat, amely elfogad egy [InterruptionToken](https://reference.aspose.com/slides/hu/java/com.aspose.slides/interruptiontoken/)—például egy prezentáció betöltése a `Presentation(path, loadOptions)` vagy mentése a `Presentation.save(...)` segítségével—megszakítható.

**Azonnal megtörténik a megszakítás?**

Nem. A megszakítás együttműködő: a művelet időközönként ellenőrzi a token-t, és amint észleli, hogy a [Interrupt()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/interruptiontokensource/#interrupt--) meghívásra került, leáll.

**Mi történik, ha a [Interrupt()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/interruptiontokensource/#interrupt--) metódust egy már befejezett feladat után hívom meg?**

Semmi—ha a megfelelő feladat már befejeződött, a hívás nem okoz semmilyen hatást.

**Újra felhasználhatom ugyanazt a [InterruptionTokenSource](https://reference.aspose.com/slides/hu/java/com.aspose.slides/interruptiontokensource/) objektumot több feladathoz?**

Igen—de miután meghívja a [Interrupt()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/interruptiontokensource/#interrupt--) metódust azon a forráson, az összes, a tokenjeit használó feladat megszakad. Használjon külön tokenforrásokat a feladatok önálló kezeléséhez.