---
title: Exportieren von Präsentationen nach HTML mit extern verlinkten Bildern
type: docs
weight: 100
url: /python-net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

Dieser Artikel beschreibt eine fortgeschrittene Technik, die es ermöglicht zu kontrollieren, welche Ressourcen in die resultierende HTML-Datei eingebettet und welche extern gespeichert und aus der HTML-Datei referenziert werden.

{{% /alert %}} 
## **Hintergrund**
Das standardmäßige Verhalten beim HTML-Export besteht darin, alle Ressourcen in die HTML-Datei einzubetten. Ein solches Vorgehen führt zu einer einzigen HTML-Datei, die leicht anzusehen und zu verteilen ist. Alle notwendigen Ressourcen sind im Base64-Format kodiert. Dieses Vorgehen hat jedoch zwei Nachteile:

- Die Größe der Ausgabe ist aufgrund der Base64-Kodierung erheblich größer.* Es ist schwierig, die im Dateiformat enthaltenen Bilder zu ersetzen.

In diesem Artikel werden wir sehen, wie wir das Standardverhalten mithilfe der **Aspose.Slides für Python über .NET** ändern können, um die Bilder extern zu verlinken, anstatt sie in die HTML-Datei einzubetten. Wir werden das **ILinkEmbedController**-Interface verwenden, das drei Methoden zur Kontrolle des Einbettungs- und Speicherprozesses von Ressourcen enthält. Wir können dieses Interface im Konstruktor der HtmlOptions-Klasse übergeben, wenn wir den Export vorbereiten.

Nachfolgend finden Sie den vollständigen Code der **LinkController**-Klasse, die das **ILinkEmbedController**-Interface implementiert. Wie bereits erwähnt, muss der LinkController das ILinkEmbedController-Interface implementieren. Dieses Interface spezifiziert drei Methoden:

- **public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)** Diese Methode wird aufgerufen, wenn der Exporteur auf eine Ressource stößt und entscheiden muss, wie sie gespeichert wird. Die wichtigsten Parameter sind „id“ – die eindeutige Identifikation der Ressource für den gesamten Exportvorgang und „contentType“ – enthält den MIME-Typ der Ressource. Wenn wir uns entscheiden, die Ressource zu verlinken, sollten wir von dieser Methode LinkEmbedDecision.Link zurückgeben. Andernfalls sollte LinkEmbedDecision.Embed zurückgegeben werden, um die Ressource einzubetten.
- **public string GetUrl(int id, int referrer)** 
  Diese Methode wird aufgerufen, um die URL der Ressource in der Form abzurufen, in der sie in der resultierenden Datei verwendet wird, sagen wir für ein <img src=”%method_result_here%”>-Tag. Die Ressource wird durch „id“ identifiziert.
- **public void SaveExternal(int id, byte[] entityData)** 
  Die letzte Methode der Sequenz wird aufgerufen, wenn es darum geht, die Ressource extern zu speichern. Wir haben die Ressourcenidentifikation und den Inhalt der Ressource als Byte-Array. Es liegt an uns, was wir mit den bereitgestellten Ressourcendaten tun.

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

Nachdem wir die **LinkController**-Klasse geschrieben haben, werden wir sie jetzt mit der **HTMLOptions**-Klasse verwenden, um die Präsentation in HTML mit extern verlinkten Bildern zu exportieren, indem wir den folgenden Code verwenden.

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

Wir haben **SlideImageFormat.Svg** der **SlideImageFormat**-Eigenschaft zugewiesen, was bedeutet, dass die resultierende HTML-Datei SVG-Daten enthält, um den Inhalt der Präsentation darzustellen.

Was die Inhaltstypen betrifft, hängt es von den tatsächlichen Bilddaten ab, die in der Präsentation enthalten sind. Wenn in der Präsentation Rastergrafiken vorhanden sind, muss der Klassencode bereit sein, sowohl „image/jpeg“ als auch „image/png“-Inhaltstypen zu verarbeiten. Der tatsächliche Inhaltstyp der exportierten Rasterbitmap-Bilder stimmt möglicherweise nicht mit dem der in der Präsentation gespeicherten Bilder überein. Die internen Algorithmen von Aspose.Slides führen eine Größenoptimierung durch und verwenden entweder JPG- oder PNG-Codecs, je nachdem, welcher ein kleineres Datenvolumen erzeugt. Bilder mit Alpha-Kanal (Transparenz) werden immer in PNG kodiert.