---
title: "Zarządzanie dostępnością prezentacji w Javie"
linktitle: "Dostępność prezentacji"
type: docs
weight: 30
url: /pl/java/presentation-accessibility/
keywords:
- "dostępność prezentacji"
- "oznacz jako ozdobny"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Java"
- "Aspose.Slides"
description: "Odkryj, jak Aspose.Slides dla Javy pomaga automatyzować sprawdzanie dostępności prezentacji w plikach PPT, PPTX i ODP — popraw doświadczenie czytników ekranu i zwiększ zgodność."
---
## **Wprowadzenie**

Zgodność prezentacji z wymogami dostępności zapewnia, że osoby korzystające z technologii wspomagających — takich jak czytniki ekranu, wyświetlacze brajlowskie lub nawigacja wyłącznie za pomocą klawiatury — mogą rozumieć i nawigować po Twoich slajdach tak efektywnie, jak widzący odbiorcy korzystający z myszy. Dobre praktyki koncentrują się na czytelnym porządku odczytu, znaczącym tekście alternatywnym dla informacyjnych grafik, wystarczającym kontraście kolorów, czytelnej typografii, opisowym tekście odnośników oraz unikaniu przekazywania znaczenia wyłącznie za pomocą koloru lub położenia. Gdy dostępność jest uwzględniana od samego początku, uzyskuje się czystszą strukturę, bardziej spójne elementy wizualne i treść docierającą do każdego odbiorcy bez obejść.

## **Oznacz jako ozdobny**

Oznacz jako ozdobny oznacza czysto dekoracyjne elementy wizualne, dzięki czemu czytniki ekranu pomijają je, redukując szum i utrzymując fokus na istotnej treści. Stosuj to dla teł, zdobień i odstępów — nigdy dla wykresów, ikon ani obrazów przekazujących informacje. Aspose.Slides udostępnia tę flagę do wykrywania i walidacji, umożliwiając automatyczne kontrole dostępności oraz czyszczenie.

![Oznacz jako ozdobny](mark_as_decorative.png)

Przykładowy kod poniżej pokazuje, jak określić, czy kształt jest oznaczony jako ozdobny.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```