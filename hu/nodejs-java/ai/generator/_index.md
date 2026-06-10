---
title: AI-vezérelt többnyelvű diákgenerátor
linktitle: AI-vezérelt generátor
type: docs
weight: 40
url: /hu/nodejs-java/ai/generator/
keywords:
- többnyelvű prezentáció
- többnyelvű dia
- AI prezentációgenerátor
- AI dia generátor
- AI-vezérelt funkció
- AI ügynök
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Készíts többnyelvű diáket szövegből az Aspose.Slides Node.js változatával. Alkalmazza saját sablonját, és exportálja a kifinomult diakészleteket PowerPoint és OpenDocument formátumba. További információ."
---
## **Bevezetés**

Az Aspose.Slides egy új, mesterséges intelligenciával működő funkciót, a Presentation Generator‑t mutatja be, amely lehetővé teszi a fejlesztők számára, hogy automatikusan jól strukturált PowerPoint‑prezentációkat hozzanak létre egyszerű szöveges bemenetekből, például téma leírásokból, összefoglalókból, idézetekből vagy felsorolásokból.

A felhasználók beállíthatják a tartalom részletezettségének szintjét, és opcionálisan saját prezentációs sablont alkalmazhatnak a vizuális tervezés meghatározásához.

Jelenleg az AI Presentation Generator a tartalmat szöveges blokkok, felsorolási listák és táblázatok segítségével struktúrálja. A képgenerálás még nem támogatott; azonban a képek könnyen hozzáadhatók utólag az Aspose.Slides eszközeivel vagy manuálisan.

A kimenet egy teljes PowerPoint‑prezentáció, amely használatra kész, vagy exportálható bármely, az Aspose.Slides API által támogatott formátumba. Bár a generátor magas színvonalú eredményeket produkál, előfordulhat, hogy kisebb utómódosításra van szükség a specifikus követelmények teljesítéséhez.

## **Hogyan működik**

Az Aspose.Slides nem tartalmaz beépített AI modelleket; helyette külső AI szolgáltatásokkal integrálódik az interneten keresztül. Ezt az integrációt a [SlidesAIAgent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesaiagent/) osztály kezeli.

Használhatja a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/openaiwebclient/)‑t, amely az OpenAI API‑hoz csatlakozik. Az Aspose.Slides kezeli az összes kommunikációt az AI szolgáltatással, és feldolgozza az AI válaszait a diákkészítéshez. Vegye figyelembe, hogy az OpenAI API fizetős szolgáltatás, ezért a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/openaiwebclient/) használatához fiók és API‑kulcs szükséges.

## **Kódoljunk**

### **Példa 1**

Ez a példa bemutatja, hogyan lehet a Aspose.Slides témában prezentációt generálni a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/openaiwebclient/) használatával.

```js
// Hozzon létre egy OpenAIWebClient példányt, az OpenAI webkliens beépített megvalósítását.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);
try {
    // Hozzon létre egy SlidesAIAgent példányt, amely hozzáférést biztosít az AI-vezérelt funkciókhoz.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Határozza meg az utasítást a prezentáció generálásához.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Generáljon egy prezentációt közepes mennyiségű tartalommal az utasítás alapján.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Medium);
    try {
        // Mentse a generált prezentációt a helyi lemezre PowerPoint (.pptx) fájlként.
        presentation.save("Aspose.Slides.NET.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

### **Példa 2**

A következő példa bemutatja a [generatePresentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesaiagent/#generatePresentation) metódus túlterheléseit. Ebben az esetben egy külsőleg kezelt [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) példány és a felhasználó `master presentation`‑ja kerül felhasználásra.

Alapértelmezés szerint a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/openaiwebclient/) saját belső [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) példányt hoz létre és kezel, automatikusan felügyelve annak életciklusát. Azonban, ha Ön saját maga szeretné kezelni a [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑t – például egy [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) vagy [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) használatával a jobb erőforrás‑kezelés és teljesítmény érdekében – akkor megadhatja saját [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) példányát a [OpenAIWebClient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/openaiwebclient/) létrehozásakor.

```js
// Adja át a HttpURLConnection-t az OpenAIWebClient konstruktorának.
var aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", "organizationId", urlConnection);
try {
    // Hozzon létre egy SlidesAIAgent példányt.
    var aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Határozza meg az utasítást a prezentáció generálásához.
    var instruction = "Generate a presentation about Aspose.Slides for .NET, highlighting its capabilities and advantages over competitors.";

    // Töltse be a fő prezentációt a helyi lemezről, hogy tervezési sablonként használja.
    var masterPresentation = new aspose.slides.Presentation("masterPresentation.pptx");

    // Generáljon részletes prezentációt az utasítás és a fő sablon felhasználásával.
    var presentation = aiAgent.generatePresentation(instruction, aspose.slides.PresentationContentAmountType.Detailed, masterPresentation);

    try {
        // Mentse a generált prezentációt PDF-ként.
        presentation.save("Aspose.Slides.NET.pdf", aspose.slides.SaveFormat.Pdf);
    } finally {
        presentation.dispose();
        masterPresentation.dispose();
    }
} finally {
    aiWebClient.close();
}
```

## **Fő előnyök**

Az Aspose.Slides új AI Presentation Generator gyors és rugalmas módot biztosít a strukturált diákkészletek előállítására egyszerű szöveges kérésből. A saját sablonok és külsőleg kezelt [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) példányok támogatásával zökkenőmentesen integrálható számos alkalmazásba.

Tipikus felhasználási esetek közé tartozik a marketingprezentációk, oktatási anyagok, ügyféljelentések és belső diákkészletek létrehozása. Bár a képgenerálás még nem támogatott, az eszköz már erős alapot nyújt a prezentációk automatizálásához, és a jövőben további fejlesztések várhatók.