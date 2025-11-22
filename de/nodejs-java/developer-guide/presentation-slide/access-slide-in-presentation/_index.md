---
title: Zugriff auf Folie in Präsentation
type: docs
weight: 20
url: /de/nodejs-java/access-slide-in-presentation/
keywords: "PowerPoint-Präsentation zugreifen, Folie zugreifen, Folieneigenschaften bearbeiten, Folienposition ändern, Foliennummer festlegen, Index, ID, Position Java, Aspose.Slides"
description: "Zugriff auf PowerPoint-Folie nach Index, ID oder Position in JavaScript. Folieneigenschaften bearbeiten"
---

Aspose.Slides ermöglicht den Zugriff auf Folien auf zwei Arten: über den Index und über die ID.

## **Zugriff auf Folie über Index**

Alle Folien in einer Präsentation sind numerisch nach ihrer Position angeordnet, beginnend bei 0. Die erste Folie ist über Index 0 zugänglich; die zweite Folie über Index 1; usw.

Die Klasse Presentation, die eine Präsentationsdatei repräsentiert, stellt alle Folien als eine [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/)‑Sammlung (Sammlung von [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/)‑Objekten) bereit. Dieser JavaScript‑Code zeigt, wie Sie über den Index auf eine Folie zugreifen:
```javascript
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Greift auf eine Folie über ihren Folienindex zu
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```


## **Zugriff auf Folie über ID**

Jede Folie in einer Präsentation besitzt eine eindeutige ID. Sie können die Methode [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse) verwenden, um diese ID anzusprechen. Dieser JavaScript‑Code zeigt, wie Sie eine gültige Folien‑ID angeben und die Folie über die [getSlideById](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlideById-long-)‑Methode abrufen:
```javascript
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Ruft eine Folien-ID ab
    var id = pres.getSlides().get_Item(0).getSlideId();
    // Greift über die ID auf die Folie zu
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```


## **Folienposition ändern**

Aspose.Slides ermöglicht das Ändern der Position einer Folie. Beispielsweise können Sie festlegen, dass die erste Folie zur zweiten Folie wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie die Referenz der Folie (deren Position Sie ändern möchten) über ihren Index.  
3. Setzen Sie eine neue Position für die Folie über die [setSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#setSlideNumber-int-)‑Eigenschaft.  
4. Speichern Sie die geänderte Präsentation.

Dieser JavaScript‑Code demonstriert einen Vorgang, bei dem die Folie an Position 1 zu Position 2 verschoben wird:
```javascript
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Holt die Folie, deren Position geändert werden soll
    var sld = pres.getSlides().get_Item(0);
    // Setzt die neue Position für die Folie
    sld.setSlideNumber(2);
    // Speichert die geänderte Präsentation
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Die erste Folie wurde zur zweiten; die zweite Folie wurde zur ersten. Beim Ändern der Position einer Folie werden andere Folien automatisch angepasst.

## **Foliennummer festlegen**

Mit der [setFirstSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-)‑Eigenschaft (bereitgestellt von der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse) können Sie eine neue Nummer für die erste Folie einer Präsentation festlegen. Dieser Vorgang führt dazu, dass die anderen Foliennummern neu berechnet werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie die Folien‑Nummer.  
3. Setzen Sie die Folien‑Nummer.  
4. Speichern Sie die geänderte Präsentation.

Dieser JavaScript‑Code demonstriert einen Vorgang, bei dem die erste Folien‑Nummer auf 10 gesetzt wird:
```javascript
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // Ermittelt die Foliennummer
    var firstSlideNumber = pres.getFirstSlideNumber();
    // Setzt die Foliennummer
    pres.setFirstSlideNumber(10);
    // Speichert die geänderte Präsentation
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Wenn Sie die erste Folie überspringen möchten, können Sie die Nummerierung ab der zweiten Folie beginnen (und die Nummerierung für die erste Folie ausblenden) wie folgt:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // Setzt die Nummer für die erste Folie der Präsentation
    presentation.setFirstSlideNumber(0);
    // Zeigt die Foliennummern für alle Folien an
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);
    // Blendet die Foliennummer für die erste Folie aus
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);
    // Speichert die geänderte Präsentation
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Stimmt die Foliennummer, die ein Benutzer sieht, mit dem nullbasierten Index der Sammlung überein?**  
Die auf einer Folie angezeigte Nummer kann bei einem beliebigen Wert beginnen (z. B. 10) und muss nicht mit dem Index übereinstimmen; die Beziehung wird durch die Einstellung [first slide number](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) der Präsentation gesteuert.

**Beeinflussen ausgeblendete Folien die Indizierung?**  
Ja. Eine ausgeblendete Folie bleibt in der Sammlung und wird bei der Indizierung mitgezählt; „ausgeblendet“ bezieht sich auf die Anzeige, nicht auf ihre Position in der Sammlung.

**Ändert sich der Index einer Folie, wenn andere Folien hinzugefügt oder entfernt werden?**  
Ja. Indizes spiegeln stets die aktuelle Reihenfolge der Folien wider und werden bei Einfüge‑, Lösch‑ und Verschiebe‑Vorgängen neu berechnet.