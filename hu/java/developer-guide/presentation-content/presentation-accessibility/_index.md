---
title: Prezentációk akadálymentességének kezelése Java-ban
linktitle: Prezentációk akadálymentessége
type: docs
weight: 30
url: /hu/java/presentation-accessibility/
keywords:
- prezentáció akadálymentesség
- dekoratívként jelölés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan segít az Aspose.Slides for Java az PPT, PPTX és ODP fájlok prezentációinak akadállyalátlansági ellenőrzésének automatizálásában - javítja a képernyőolvasók élményét és növeli a megfelelőséget."
---
## **Bevezetés**

A bemutató akadálymentessége biztosítja, hogy a segítő technológiákat—például képernyőolvasókat, Braille kijelzőket vagy csak billentyűzettel történő navigációt—használó emberek ugyanolyan hatékonyan megértsék és böngésszék a diáidat, mint a látó, egérrel dolgozó közönség. A jó gyakorlat a világos olvasási sorrendre, az informatív képek értelmes alternatív szövegére, a megfelelő színkontrasztra, az olvasható tipográfiára, a leíró hivatkozásszövegre, valamint arra összpontosít, hogy elkerülje a jelentés szín vagy pozíció alapján történő közvetítését. Ha az akadálymentességet már a kezdetektől tervezik, az eredmény egy tisztább szerkezet, egységesebb vizuális elemek és olyan tartalom, amely minden nézőhöz eljut megkerülések nélkül.

## **Dekoratívként megjelölés**

A „Dekoratívként megjelölés” jelző a pusztán díszítő elemeket jelöli meg, így a képernyőolvasók kihagyják azokat, csökkentve a zajt és a figyelmet a lényeges tartalomra irányítva. Alkalmazd hátterekre, díszítő elemekre és elválasztókra—soha diagramokra, ikonokra vagy információt közvetítő képekre. Az Aspose.Slides elérhetővé teszi ezt a jelzőt a detektáláshoz és validáláshoz, lehetővé téve az automatikus akadálymentességi ellenőrzéseket és tisztítást.

![Dekoratívként megjelölés](mark_as_decorative.png)

Az alábbi kódminta bemutatja, hogyan lehet megállapítani, hogy egy alakzat dekoratívként van-e megjelölve.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```