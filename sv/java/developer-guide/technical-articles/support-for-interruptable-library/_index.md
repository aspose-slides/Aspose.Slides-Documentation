---
title: Stöd för avbrottsbiblioteket
type: docs
weight: 120
url: /sv/java/support-for-interruptable-library/
keywords:
- avbrottsbibliotek
- avbrottstoken
- avbrytningstoken
- långvarig uppgift
- avbryt uppgift
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Gör långvariga uppgifter avbrytbara med Aspose.Slides för Java. Avbryt rendering och konverteringar för PowerPoint och OpenDocument på ett säkert sätt, med exempel."
---
## **Översikt**

Aspose.Slides tillhandahåller en avbrytbar bearbetningsmekanism för långvariga presentationstasks, såsom deserialisering, serialisering och rendering. Denna mekanism bygger på klasserna `InterruptionToken` och `InterruptionTokenSource`.

`InterruptionToken` kan tilldelas `LoadOptions` och skickas till `Presentation`‑konstruktören. När `InterruptionTokenSource.interrupt()` anropas avbryts den associerade långvariga uppgiften.

## **Avbrottsbibliotek**

I [Aspose.Slides 18.4](https://releases.aspose.com/slides/sv/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/) introducerade vi klasserna [InterruptionToken](https://reference.aspose.com/slides/sv/java/com.aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/sv/java/com.aspose.slides/interruptiontokensource/). De gör det möjligt att avbryta långvariga uppgifter såsom deserialisering, serialisering och rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/sv/java/com.aspose.slides/interruptiontokensource/) är källan till token(s) som skickas till [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- När [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) är satt och [LoadOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadoptions/)‑instansen skickas till [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)-konstruktören, avbryter anropet av [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/interruptiontokensource/#interrupt--) alla långvariga uppgifter som är associerade med den [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).

Följande kodexempel demonstrerar hur man avbryter en pågående uppgift:

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
thread.start();          // kör åtgärden i en separat tråd
Thread.sleep(10000);     // tidsgräns
tokenSource.interrupt(); // stoppa konverteringen
```

## **FAQ**

**Vad är syftet med Aspose.Slides avbrottsbiblioteket?**

Det tillhandahåller en mekanism för att avbryta långvariga operationer — såsom inläsning, sparande eller rendering av presentationer — innan de slutförs. Detta är användbart när bearbetningstiden måste begränsas eller uppgiften inte längre behövs.

**Vad är skillnaden mellan [InterruptionToken](https://reference.aspose.com/slides/sv/java/com.aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/sv/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` skickas till Aspose.Slides‑API:et och kontrolleras under långvariga operationer.
- `InterruptionTokenSource` används i din kod för att skapa token och utlösa avbrott genom att anropa `Interrupt()`.

**Vilka uppgifter kan avbrytas?**

Alla Aspose.Slides‑uppgifter som accepterar en [InterruptionToken](https://reference.aspose.com/slides/sv/java/com.aspose.slides/interruptiontoken/) — såsom att ladda en presentation med `Presentation(path, loadOptions)` eller spara med `Presentation.save(...)` — kan avbrytas.

**Sker avbrott omedelbart?**

Nej. Avbrott är samarbetsbaserat: operationen kontrollerar token periodiskt och stoppar så snart den upptäcker att [Interrupt()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/interruptiontokensource/#interrupt--) har anropats.

**Vad händer om jag anropar [Interrupt()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/interruptiontokensource/#interrupt--) efter att en uppgift redan har slutförts?**

Ingenting — anropet har ingen effekt om den motsvarande uppgiften redan har slutförts.

**Kan jag återanvända samma [InterruptionTokenSource](https://reference.aspose.com/slides/sv/java/com.aspose.slides/interruptiontokensource/) för flera uppgifter?**

Ja — men efter att du har anropat [Interrupt()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/interruptiontokensource/#interrupt--) på den källan avbryts alla uppgifter som använder dess token. Använd separata token‑källor för att hantera uppgifter oberoende.