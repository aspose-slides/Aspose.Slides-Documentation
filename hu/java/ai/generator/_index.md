---
title: AI-vezérelt többnyelvű dia generátor
linktitle: AI-vezérelt generátor
type: docs
weight: 40
url: /hu/java/ai/generator/
keywords:
- többnyelvű prezentáció
- többnyelvű dia
- AI prezentációgenerátor
- AI dia generátor
- AI-alapú funkció
- AI ügynök
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Készítsen többnyelvű diákat szövegből az Aspose.Slides for Java használatával. Alkalmazza a sablonját, és exportálja a kifogástalan prezentációkat PowerPoint és OpenDocument formátumba. További információ."
---
## **Bevezetés**

Az Aspose.Slides egy új AI-alapú funkciót, a Presentation Generator‑t mutat be, amely lehetővé teszi a fejlesztők számára, hogy egyszerű szöveges bemenetek – például téma leírások, összefoglalók, idézetek vagy felsorolások – alapján automatikusan jól strukturált PowerPoint‑prezentációkat hozzanak létre.

A felhasználók beállíthatják a tartalom részletezettségének szintjét, és opcionálisan alkalmazhatnak egy egyéni prezentációs sablont a vizuális megjelenés meghatározásához.

Jelenleg az AI Presentation Generator szöveges blokkokkal, felsoroláslistákkal és táblázatokkal struktúrázza a tartalmat. A képgenerálás még nem támogatott; azonban a képek később könnyen hozzáadhatók az Aspose.Slides eszközeivel vagy manuálisan.

A kimenet egy teljes PowerPoint‑prezentáció, amely használatra kész vagy exportálható bármely, az Aspose.Slides API által támogatott formátumba. Bár a generátor magas minőségű eredményeket produkál, előfordulhat, hogy kisebb utólagos szerkesztésre van szükség a specifikus követelmények teljesítéséhez.

## **Hogyan működik**

Az Aspose.Slides nem tartalmaz beépített AI modelleket; helyette külső AI szolgáltatásokkal integrálódik az interneten keresztül. Az integrációt a [SlidesAIAgent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidesaiagent/) osztály kezeli, amely egy [IAIWebClient](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iaiwebclient/) interfész implementációját használja az AI modelllel való kommunikációhoz.

Használhatja a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/java/com.aspose.slides/openaiwebclient/)‑t, amely az OpenAI API‑hoz csatlakozik, vagy biztosíthat egy egyéni [IAIWebClient](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iaiwebclient/) implementációt egy másik AI szolgáltatóval vagy nyelvi modellel való munkához. Az Aspose.Slides kezeli az összes kommunikációt az AI szolgáltatással, és feldolgozza az AI válaszait a diák létrehozásához. Vegye figyelembe, hogy az OpenAI API fizetős szolgáltatás, ezért fiókra és API kulcsra van szükség a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/java/com.aspose.slides/openaiwebclient/) használatakor.

## **Kódoljunk**

### **Példa 1**

Ez a példa bemutatja, hogyan lehet egy Aspose.Slides témájú prezentációt generálni a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/java/com.aspose.slides/openaiwebclient/) használatával.

```java
// Hozzon létre egy OpenAIWebClient példányt, az OpenAI webkliens beépített megvalósítását.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Hozzon létre egy SlidesAIAgent példányt, amely AI-alapú funkciókhoz biztosít hozzáférést.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definiálja a prezentáció generálásának utasítását.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Generáljon egy prezentációt közepes tartalom mennyiséggel az utasítás alapján.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Medium);
    try {
    // Mentse a generált prezentációt a helyi lemezre PowerPoint (.pptx) fájlként.
    presentation.save("Aspose.Slides.NET.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Példa 2**

A következő példa bemutatja a [generatePresentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slidesaiagent/#generatePresentation-java.lang.String-int-) metódus túlterheléseit. Ebben az esetben egy külsőleg kezelt [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) példány és a felhasználó `master presentation` ja van használva.

Alapértelmezés szerint a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/java/com.aspose.slides/openaiwebclient/) hozza létre és kezeli saját belső [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) példányát, automatikusan kezelve annak életciklusát. Azonban, ha saját magának szeretné kezelni a [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑t – például egy [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) vagy [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) használatakor a jobb erőforrás‑kezelés és teljesítmény érdekében – megadhatja saját [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) példányát a [OpenAIWebClient](https://reference.aspose.com/slides/hu/java/com.aspose.slides/openaiwebclient/) konstrukciójakor.

```java
// Adja át a HttpURLConnection-t az OpenAIWebClient konstruktorának.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Hozzon létre egy SlidesAIAgent példányt.
    var aiAgent = new SlidesAIAgent(aiWebClient);

    // Definiálja a prezentáció generálásának utasítását.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Töltsön be egy mesterprezentációt a helyi lemezről, amelyet a design sablonként használ.
    Presentation masterPresentation = new Presentation("masterPresentation.pptx");

    // Generáljon egy részletes prezentációt az utasítás és a mester sablon felhasználásával.
    IPresentation presentation = aiAgent.generatePresentation(instruction, PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Mentse a generált prezentációt PDF-ként.
        presentation.save("Aspose.Slides.NET.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Kulcsfontosságú előnyök**

Az Aspose.Slides új AI Presentation Generator gyors és rugalmas módot biztosít struktúrált diákészletek létrehozására egyszerű szöveges kérésből. Az egyéni sablonok és külsőleg kezelt [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) példányok támogatásával zökkenőmentesen integrálható számos alkalmazásba.

A tipikus felhasználási esetek közé tartozik marketing prezentációk, oktatási anyagok, ügyféljelentések és belső diákészletek készítése. Bár a képgenerálás még nem támogatott, az eszköz már most erős alapot nyújt a prezentációk automatizálásához, és a jövőben további fejlesztések várhatók.