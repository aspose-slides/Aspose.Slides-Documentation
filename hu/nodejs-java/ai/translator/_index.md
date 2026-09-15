---
title: AI-alapú prezentáció fordító
linktitle: AI-alapú fordító
type: docs
weight: 20
url: /hu/nodejs-java/ai/translator/
keywords:
- AI prezentáció fordító
- AI dia fordító
- AI-alapú funkció
- többnyelvű prezentáció
- többnyelvű dia
- prezentáció fordítás
- dia fordítás
- AI által vezérelt funkciók
- AI képességek
- AI ügynök
- Web kliens
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fordítsa le a PowerPoint diákot AI segítségével az Aspose.Slides for Node.js használatával. Lokálisan készítse el a PPT, PPTX és ODP fájlokat a elrendezés megőrzésével — gyors és fejlesztőbarát. Próbálja ki."
---
## **Bevezetés**

Az Aspose.Slides egy erőteljes API a PowerPoint-prezentációk programozott kezeléséhez. A diák létrehozása, szerkesztése és konvertálása mellett AI-alapú funkciókat is kínál – például a Presentation Translation API-t a többnyelvű dias tartalomhoz.

## **Működés**

Az Aspose.Slides beépített AI képességekkel nem rendelkezik, hanem az interneten keresztül külső AI modellekkel integrálódik. Ez a funkcionalitás a [SlidesAIAgent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesaiagent/) osztályon keresztül érhető el az AI szolgáltatásokkal való kommunikációhoz.

A beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/openaiwebclient/) használatával csatlakozhat az OpenAI API-hoz.

Az Aspose.Slides kezeli a kommunikációt, feldolgozza az AI válaszokat, és intelligensen beilleszti a lefordított tartalmat, miközben megőrzi az eredeti diák elrendezését és formázását.

{{% alert color="info" title="Note" %}}
Vegye figyelembe, hogy az OpenAI API fizetős szolgáltatás, ezért fiókot kell létrehoznia és meg kell adnia az API kulcsát a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/openaiwebclient/) használatakor.
{{% /alert %}}

## **Példa**

Ebben a példában a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/openaiwebclient/) segítségével egy PowerPoint-prezentációt fordítunk le japán nyelvre egy meghatározott OpenAI [modellel](https://platform.openai.com/docs/models).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Töltsön be egy prezentációt a fordításhoz.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicializálja a SlidesAIAgent-et az AI klienssel.
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);

    // Fordítsa le a prezentációt japánra.
    aiAgent.translate(presentation, "japanese");

    // Mentse a lefordított prezentációt PDF-ként.
    presentation.save("sample_jp.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Alapértelmezés szerint a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/openaiwebclient/) saját belső [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) példányt hoz létre és kezel, automatikusan gondoskodva annak életciklusáról. Ha azonban szeretné saját kezében tartani a [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) kezelését — elsősorban olyan alapvető beállítások, például proxy konfigurálásához, vagy egy [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) vagy egy másik [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) használatához a jobb erőforrás-kezelés és teljesítmény érdekében — megadhatja saját `HttpURLConnection` példányát a [OpenAIWebClient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/openaiwebclient/) létrehozásakor.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Hozzon létre és előkonfiguráljon egy HttpURLConnection példányt (például egyéni időkorlátokkal, proxy beállításokkal stb.)
let url = java.newInstanceSync("java.net.URL", "https://api.openai.com/v1/chat/completions");
let urlConnection = url.openConnection();
urlConnection.setConnectTimeout(10000);
urlConnection.setReadTimeout(60000);

let aiWebClient = new aspose.slides.OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
```

### **Azure OpenAI példa**

A fordítót úgy konfigurálhatja, hogy az Azure OpenAI telepítését használja a [OpenAICompatibleWebClient](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/openaicompatiblewebclient/) segítségével.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let model = "your-azure-deployment-name";
let apiKey = "your-azure-api-key";
let baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

let aiWebClient = new aspose.slides.OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    let aiAgent = new aspose.slides.SlidesAIAgent(aiWebClient);
    let presentation = new aspose.slides.Presentation("presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```
Ez a kódrészlet bemutatja egy prezentáció lefordítását az Azure OpenAI végpontjával. Cserélje ki a helyőrző értékeket a telepítés nevére, az API kulcsra és a végpont URL-jére.

## **Fő előnyök**

Az Aspose.Slides Presentation Translation API AI-alapú megoldást kínál a többnyelvű PowerPoint-prezentációk megjelenítésére. A fordítás automatizálásával, miközben megőrzi az elrendezést és a dizájnt, időt takarít meg, és csökkenti a hibákat a manuális munkafolyamatokhoz képest. Akár fejlesztő, oktató vagy üzleti szakember, ez az API lehetővé teszi, hogy vonzó, helyi nyelvre szabott prezentációkat hozzon létre globális közönség számára — bővítve elérését és javítva a kommunikációt.