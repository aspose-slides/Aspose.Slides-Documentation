---
title: Unterstützung für Interruptable-Bibliothek
type: docs
weight: 120
url: /de/java/support-for-interruptable-library/
keywords:
  - Interruptable Bibliothek
  - Interruptions-Token
  - Abbruch-Token
  - langlaufende Aufgabe
  - Aufgabe unterbrechen
  - PowerPoint
  - OpenDocument
  - Präsentation
  - Java
  - Aspose.Slides
description: "Machen Sie langlaufende Aufgaben mit Aspose.Slides für Java abbrechbar. Unterbrechen Sie das Rendern und die Konvertierung von PowerPoint und OpenDocument sicher, mit Beispielen."
---

## **Interruptable Bibliothek**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/), haben wir die Klassen [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) eingeführt. Sie ermöglichen das Unterbrechen von langlaufenden Aufgaben wie Deserialisierung, Serialisierung und Rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) ist die Quelle des/der Token(s), die an [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) übergeben werden.
- Wenn [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) gesetzt ist und die [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/)‑Instanz an den [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)-Konstruktor übergeben wird, unterbricht das Aufrufen von [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) jede langlaufende Aufgabe, die mit dieser [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) verknüpft ist.

Der folgende Code‑Abschnitt demonstriert das Unterbrechen einer laufenden Aufgabe:
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
thread.start();          // die Aktion in einem separaten Thread ausführen
Thread.sleep(10000);     // Zeitüberschreitung
tokenSource.interrupt(); // die Konvertierung stoppen
```


## **FAQ**

**Was ist der Zweck der Aspose.Slides Interrupt‑Bibliothek?**

Sie bietet einen Mechanismus, um langlaufende Vorgänge – wie das Laden, Speichern oder Rendern von Präsentationen – vor deren Abschluss zu unterbrechen. Dies ist nützlich, wenn die Verarbeitungszeit begrenzt werden muss oder der Vorgang nicht mehr benötigt wird.

**Was ist der Unterschied zwischen [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) und [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` wird an die Aspose.Slides‑API übergeben und während langlaufender Vorgänge geprüft.
- `InterruptionTokenSource` wird in Ihrem Code verwendet, um Token zu erstellen und Unterbrechungen auszulösen, indem `Interrupt()` aufgerufen wird.

**Welche Aufgaben können unterbrochen werden?**

Jede Aspose.Slides‑Aufgabe, die ein [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) akzeptiert – beispielsweise das Laden einer Präsentation mit `Presentation(path, loadOptions)` oder das Speichern mit `Presentation.save(...)` – kann unterbrochen werden.

**Findet die Unterbrechung sofort statt?**

Nein. Die Unterbrechung ist kooperativ: Der Vorgang prüft periodisch das Token und stoppt, sobald er feststellt, dass `Interrupt()` aufgerufen wurde.

**Was passiert, wenn ich `Interrupt()` aufrufe, nachdem ein Vorgang bereits abgeschlossen ist?**

Nichts – der Aufruf hat keine Wirkung, wenn der entsprechende Vorgang bereits abgeschlossen ist.

**Kann ich dieselbe [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) für mehrere Aufgaben wiederverwenden?**

Ja – jedoch werden nach dem Aufruf von `Interrupt()` auf dieser Quelle alle Aufgaben, die deren Token verwenden, unterbrochen. Verwenden Sie separate Token‑Quellen, um Aufgaben unabhängig zu verwalten.