---
title: Wsparcie dla biblioteki przerwalnej
type: docs
weight: 120
url: /pl/java/support-for-interruptable-library/
keywords:
- biblioteka przerwalna
- token przerwania
- token anulowania
- długotrwałe zadanie
- przerwanie zadania
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Umożliwiaj anulowanie długotrwałych zadań za pomocą Aspose.Slides dla Javy. Bezpiecznie przerywaj renderowanie i konwersje dla PowerPoint i OpenDocument, z przykładami."
---
## **Przegląd**

Aspose.Slides udostępnia mechanizm przetwarzania z możliwością przerwania dla długotrwałych zadań związanych z prezentacjami, takich jak deserializacja, serializacja i renderowanie. Mechanizm ten opiera się na klasach `InterruptionToken` i `InterruptionTokenSource`.

`InterruptionToken` może być przypisany do `LoadOptions` i przekazany do konstruktora `Presentation`. Gdy wywołana zostanie metoda `InterruptionTokenSource.interrupt()`, powiązane długotrwałe zadanie zostaje przerwane.

## **Biblioteka z możliwością przerwania**

W wersji [Aspose.Slides 18.4](https://releases.aspose.com/slides/pl/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/) wprowadziliśmy klasy [InterruptionToken](https://reference.aspose.com/slides/pl/java/com.aspose.slides/interruptiontoken/) i [InterruptionTokenSource](https://reference.aspose.com/slides/pl/java/com.aspose.slides/interruptiontokensource/). Umożliwiają one przerywanie długotrwałych zadań, takich jak deserializacja, serializacja i renderowanie.

- [InterruptionTokenSource](https://reference.aspose.com/slides/pl/java/com.aspose.slides/interruptiontokensource/) jest źródłem tokenu(ów) przekazywanych do [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- Gdy metoda [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) zostanie ustawiona i instancja [LoadOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/) zostanie przekazana do konstruktora [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/), wywołanie [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/interruptiontokensource/#interrupt--) przerywa każde długotrwałe zadanie powiązane z tą [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).

Poniższy fragment kodu demonstruje przerywanie uruchomionego zadania:

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
thread.start();          // uruchom akcję w osobnym wątku
Thread.sleep(10000);     // limit czasu
tokenSource.interrupt(); // zatrzymaj konwersję
```

## **FAQ**

**Jaki jest cel biblioteki przerwań Aspose.Slides?**

Zapewnia mechanizm pozwalający przerwać długotrwałe operacje — takie jak wczytywanie, zapisywanie lub renderowanie prezentacji — przed ich zakończeniem. Jest to przydatne, gdy czas przetwarzania musi być ograniczony lub zadanie nie jest już potrzebne.

**Jaka jest różnica między [InterruptionToken](https://reference.aspose.com/slides/pl/java/com.aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/pl/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` jest przekazywany do API Aspose.Slides i sprawdzany podczas długotrwałych operacji.
- `InterruptionTokenSource` jest używany w kodzie do tworzenia tokenów i wyzwalania przerwań poprzez wywołanie `Interrupt()`.

**Jakie zadania można przerwać?**

Każde zadanie Aspose.Slides, które akceptuje [InterruptionToken](https://reference.aspose.com/slides/pl/java/com.aspose.slides/interruptiontoken/) — na przykład wczytywanie prezentacji przy użyciu `Presentation(path, loadOptions)` lub zapisywanie przy pomocy `Presentation.save(...)` — może zostać przerwane.

**Czy przerwanie następuje natychmiast?**

Nie. Przerwanie jest współpracujące: operacja okresowo sprawdza token i zatrzymuje się, gdy tylko wykryje, że wywołano [Interrupt()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/interruptiontokensource/#interrupt--).

**Co się stanie, jeśli wywołam [Interrupt()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/interruptiontokensource/#interrupt--) po zakończeniu zadania?**

Nic — wywołanie nie ma żadnego efektu, jeśli odpowiednie zadanie już się zakończyło.

**Czy mogę ponownie używać tego samego [InterruptionTokenSource](https://reference.aspose.com/slides/pl/java/com.aspose.slides/interruptiontokensource/) dla wielu zadań?**

Tak — ale po wywołaniu [Interrupt()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/interruptiontokensource/#interrupt--) na tym źródle, wszystkie zadania korzystające z jego tokenów zostaną przerwane. Używaj oddzielnych źródeł tokenów, aby zarządzać zadaniami niezależnie.