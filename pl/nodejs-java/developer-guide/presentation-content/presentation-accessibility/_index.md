---
title: Zarządzanie dostępnością prezentacji w JavaScript
linktitle: Dostępność prezentacji
type: docs
weight: 30
url: /pl/nodejs-java/presentation-accessibility/
keywords:
- dostępność prezentacji
- oznacz jako dekoracyjne
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatyzuj kontrole dostępności prezentacji w plikach PPT, PPTX i ODP przy użyciu Aspose.Slides dla Node.js — popraw doświadczenie czytników ekranu i zwiększ zgodność."
---
## **Przegląd**

Dostępność prezentacji zapewnia, że osoby korzystające z technologii wspomagających — takich jak czytniki ekranu, wyświetlacze brajlowskie lub nawigacja wyłącznie przy użyciu klawiatury — mogą rozumieć i poruszać się po Twoich slajdach tak samo skutecznie, jak widzący odbiorcy korzystający z myszy. Dobre praktyki koncentrują się na czytelnym porządku odczytu, znaczącym tekście alternatywnym dla ilustracji informacyjnych, odpowiednim kontraście kolorów, czytelnej typografii, opisowym tekście odnośników oraz unikaniu przekazywania znaczenia wyłącznie za pomocą koloru lub położenia. Gdy dostępność jest planowana od samego początku, rezultatem jest czystsza struktura, bardziej spójne elementy wizualne oraz treść, która dociera do każdego odbiorcy bez obejść.

## **Oznacz jako dekoracyjne**

Oznacz jako dekoracyjne oznacza czysto ozdobne elementy wizualne, aby czytniki ekranu je pomijały, co redukuje szum i utrzymuje fokus na istotnej treści. Stosuj to dla tła, ozdobników i wypełniaczy — nigdy dla wykresów, ikon ani obrazów przekazujących informacje. Aspose.Slides udostępnia tę flagę do wykrywania i walidacji, umożliwiając automatyczne kontrole dostępności oraz czyszczenie.

![Oznacz jako dekoracyjne](mark_as_decorative.png)

Poniższy przykład kodu pokazuje, jak określić, czy kształt został oznaczony jako dekoracyjny.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Is shape decorative:", shape.isDecorative());
} finally {
    presentation.dispose();
}
```