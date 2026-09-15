---
title: AI-alapú prezentációfordító
linktitle: AI-alapú fordító
type: docs
weight: 20
url: /hu/php-java/ai/translator/
keywords:
- AI prezentációfordító
- AI diafordító
- AI-alapú funkció
- többnyelvű prezentáció
- többnyelvű dia
- prezentációfordítás
- diafordítás
- AI-vezérelt funkciók
- AI képességek
- AI ügynök
- Web kliens
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Fordítsa le a PowerPoint diákot AI-val az Aspose.Slides for PHP használatával. Lokalizálja a PPT, PPTX és ODP fájlokat a elrendezés megőrzése mellett – gyors és fejlesztőbarát. Próbálja ki."
---
## **Bevezetés**

Az Aspose.Slides egy nagy teljesítményű API a PowerPoint prezentációk programozott kezeléséhez. A diák létrehozása, szerkesztése és konvertálása mellett AI-alapú funkciókat is kínál – például a Prezentációfordítás API-t a többnyelvű diatartalomhoz.

## **Hogyan működik**

Az Aspose.Slides beépített AI‑képességekkel nem rendelkezik, hanem interneten keresztül külső AI modellekkel integrálódik. Ez a funkció a [SlidesAIAgent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesaiagent/) osztályon keresztül érhető el az AI szolgáltatásokkal való kommunikációhoz.

Használhatja a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/php-java/aspose.slides/openaiwebclient/) osztályt az OpenAI API‑hoz való csatlakozáshoz.

Az Aspose.Slides kezeli a kommunikációt, feldolgozza az AI válaszokat, és intelligensen beilleszti a lefordított tartalmat, miközben megőrzi az eredeti dia elrendezését és formázását.

{{% alert color="info" title="Note" %}}
Megjegyzés: az OpenAI API fizetős szolgáltatás, ezért fiókot kell létrehoznia, és meg kell adnia az API kulcsát a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/php-java/aspose.slides/openaiwebclient/) használatakor.
{{% /alert %}}

## **Példa**

Ebben a példában a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/php-java/aspose.slides/openaiwebclient/) és egy megadott OpenAI [model](https://platform.openai.com/docs/models) segítségével fordítjuk le a PowerPoint prezentációt japánra.

```php
// Töltsön be egy prezentációt a fordításhoz.
$presentation = new Presentation("sample.pptx");

// Create an AI client with OpenAIWebClient, specifying your model and API key.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicializálja a SlidesAIAgent-et az AI klienssel.
    $aiAgent = new SlidesAIAgent($aiWebClient);

    // Fordítsa le a prezentációt japánra.
    $aiAgent->translate($presentation, "japanese");

    // Mentse a lefordított prezentációt PDF-ként.
    $presentation->save("sample_jp.pdf", SaveFormat::Pdf);
} finally {
    $aiWebClient->close();
    $presentation->dispose();
}
```

Alapértelmezés szerint a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/php-java/aspose.slides/openaiwebclient/) saját belső [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) példányt hoz létre és kezel, automatikusan felügyelve annak életciklusát. Azonban, ha saját maga szeretné kezelni a [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)-t – elsősorban olyan alapvető beállítások, például proxy konfigurálása, vagy egy [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) vagy egy másik [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) használata a jobb erőforrás‑kezelés és teljesítmény érdekében – akkor a [OpenAIWebClient](https://reference.aspose.com/slides/hu/php-java/aspose.slides/openaiwebclient/) létrehozásakor megadhatja a saját `HttpURLConnection` példányát.

```php
// Hozzon létre és előkonfigurálja saját HttpURLConnection példányát (egyéni időkorlátok, proxy beállítások, stb.).
$url = new Java("java.net.URL", "https://api.openai.com/v1/chat/completions");
$urlConnection = $url->openConnection();
$urlConnection->setConnectTimeout(10000);
$urlConnection->setReadTimeout(60000);

// Adja át a kapcsolatot az AI kliensnek.
$aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, $urlConnection);
```

### **Azure OpenAI példa**

A fordítót úgy konfigurálhatja, hogy az Azure OpenAI telepítését használja a [OpenAICompatibleWebClient](https://reference.aspose.com/slides/hu/php-java/aspose.slides/openaicompatiblewebclient/) segítségével.

```php
use aspose\slides\OpenAICompatibleWebClient;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlidesAIAgent;

$model = "your-azure-deployment-name";
$apiKey = "your-azure-api-key";
$baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

$aiWebClient = new OpenAICompatibleWebClient($model, $apiKey, $baseUrl);
try {
    $aiAgent = new SlidesAIAgent($aiWebClient);
    $presentation = new Presentation("Presentation.pptx");
    try {
        $aiAgent->translate($presentation, "spanish");
        $presentation->save("Translated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $aiWebClient->dispose();
}
```

Ez a kódrészlet bemutatja egy prezentáció fordítását az Azure OpenAI végpontjával. Cserélje ki a helyőrző értékeket a telepítés neve, API kulcs és a végpont URL címére.

## **Kulcsfontosságú előnyök**

Az Aspose.Slides Presentation Translation API AI‑alapú megoldást kínál a többnyelvű PowerPoint prezentációk előállításához. A fordítás automatizálásával, miközben megőrzi az elrendezést és a tervezést, időt takarít meg és csökkenti a hibákat a manuális munkafolyamatokhoz képest. Legyen Ön fejlesztő, oktató vagy üzleti szakember, ez az API lehetővé teszi vonzó, lokalizált prezentációk létrehozását a globális közönség számára – ezáltal bővítve elérését és javítva a kommunikációt.