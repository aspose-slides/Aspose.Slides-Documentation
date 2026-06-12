---
title: Podpora přerušitelné knihovny
type: docs
weight: 120
url: /cs/java/support-for-interruptable-library/
keywords:
- přerušitelná knihovna
- token přerušení
- token zrušení
- dlouhotrvající úloha
- přerušit úlohu
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Umožněte zrušení dlouhotrvajících úloh pomocí Aspose.Slides pro Java. Bezpečně přerušujte vykreslování a konverze pro PowerPoint a OpenDocument, včetně příkladů."
---
## **Přehled**

Aspose.Slides poskytuje přerušitelný mechanismus zpracování pro dlouhotrvající úlohy prezentací, jako je deserializace, serializace a vykreslování. Tento mechanismus je založen na třídách `InterruptionToken` a `InterruptionTokenSource`.

`InterruptionToken` lze přiřadit k `LoadOptions` a předat konstruktoru `Presentation`. Když je zavoláno `InterruptionTokenSource.interrupt()`, související dlouhotrvající úloha je přerušena.

## **Přerušitelná knihovna**

V [Aspose.Slides 18.4](https://releases.aspose.com/slides/cs/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/) jsme představili třídy [InterruptionToken](https://reference.aspose.com/slides/cs/java/com.aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/cs/java/com.aspose.slides/interruptiontokensource/). Umožňují přerušit dlouhotrvající úlohy, jako je deserializace, serializace a vykreslování.

- [InterruptionTokenSource](https://reference.aspose.com/slides/cs/java/com.aspose.slides/interruptiontokensource/) je zdroj tokenu(ů) předávaných do [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- Když je nastaven [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) a instance [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/) je předána konstruktoru [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), volání [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/interruptiontokensource/#interrupt--) přeruší jakoukoli dlouhotrvající úlohu spojenou s touto [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).

Následující úryvek kódu ukazuje, jak přerušit běžící úlohu:

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
thread.start();          // spustit akci v samostatném vláknu
Thread.sleep(10000);     // časový limit
tokenSource.interrupt(); // zastavit konverzi
```

## **Často kladené otázky**

**Jaký je účel přerušitelné knihovny Aspose.Slides?**

Poskytuje mechanismus pro přerušení dlouhotrvajících operací — například načítání, ukládání nebo vykreslování prezentací — před jejich dokončením. To je užitečné, když je třeba omezit čas zpracování nebo úloha již není potřebná.

**Jaký je rozdíl mezi [InterruptionToken](https://reference.aspose.com/slides/cs/java/com.aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/cs/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` se předává API Aspose.Slides a během dlouhotrvajících operací se periodicky kontroluje.
- `InterruptionTokenSource` slouží ve vašem kódu k vytváření tokenů a spouštění přerušení voláním `Interrupt()`.

**Jaké úlohy lze přerušit?**

Jakákoli úloha Aspose.Slides, která přijímá [InterruptionToken](https://reference.aspose.com/slides/cs/java/com.aspose.slides/interruptiontoken/) — například načtení prezentace pomocí `Presentation(path, loadOptions)` nebo uložení pomocí `Presentation.save(...)` — může být přerušena.

**Proběhne přerušení okamžitě?**

Ne. Přerušení je kooperativní: operace pravidelně kontroluje token a zastaví se, jakmile zjistí, že bylo zavoláno [Interrupt()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/interruptiontokensource/#interrupt--).

**Co se stane, když zavolám [Interrupt()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/interruptiontokensource/#interrupt--) po dokončení úlohy?**

Nic — volání nemá žádný efekt, pokud byla příslušná úloha již dokončena.

**Mohu znovu použít stejný [InterruptionTokenSource](https://reference.aspose.com/slides/cs/java/com.aspose.slides/interruptiontokensource/) pro více úloh?**

Ano — ale po volání [Interrupt()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/interruptiontokensource/#interrupt--) na tomto zdroji budou všechny úlohy používající jeho tokeny přerušeny. Pro samostatné řízení úloh použijte oddělené zdroje tokenů.