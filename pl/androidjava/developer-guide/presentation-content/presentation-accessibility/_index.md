---
title: Zarządzaj dostępnością prezentacji w systemie Android
linktitle: Dostępność prezentacji
type: docs
weight: 30
url: /pl/androidjava/presentation-accessibility/
keywords:
- dostępność prezentacji
- oznacz jako dekoracyjne
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla Androida w Java pomaga automatyzować sprawdzanie dostępności prezentacji w plikach PPT, PPTX i ODP — popraw doświadczenie czytników ekranu i zwiększ zgodność."
---
## **Przegląd**

Dostępność prezentacji zapewnia, że osoby korzystające z technologii wspomagających — takich jak czytniki ekranu, wyświetlacze brajlowskie lub nawigacja przy użyciu wyłącznie klawiatury — mogą rozumieć i nawigować po slajdach tak skutecznie, jak widzące osoby używające myszy. Dobre praktyki koncentrują się na czytelnym porządku odczytu, znaczącym tekście alternatywnym dla wizualizacji informacyjnych, odpowiednim kontraście kolorów, czytelnej typografii, opisowym tekście odnośników oraz unikaniu przekazywania znaczenia wyłącznie poprzez kolor lub pozycję. Gdy dostępność jest planowana od samego początku, rezultatem jest czystsza struktura, bardziej spójne elementy wizualne oraz treść, która dociera do każdego odbiorcy bez obejść.

## **Oznacz jako dekoracyjne**

Flaga „Mark as decorative” oznacza wyłącznie ozdobne elementy graficzne, dzięki czemu czytniki ekranu je pomijają, ograniczając szum i utrzymując uwagę na istotnych treściach. Stosuj ją do tła, zdobień i odstępów — nigdy do wykresów, ikon ani obrazów przekazujących informacje. Aspose.Slides udostępnia tę flagę do wykrywania i walidacji, umożliwiając automatyczne kontrole dostępności i czyszczenie.

![Mark as Decorative](mark_as_decorative.png)

Poniższy przykład kodu pokazuje, jak ustalić, czy kształt jest oznaczony jako dekoracyjny.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```