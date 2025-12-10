---
title: Effektive Formeigenschaften aus Präsentationen in C++ abrufen
linktitle: Effektive Eigenschaften
type: docs
weight: 50
url: /de/cpp/shape-effective-properties/
keywords:
- Formeigenschaften
- Kameraeigenschaften
- Licht Rig
- Abgeschrägte Form
- Textfeld
- Textstil
- Schriftgröße
- Füllformat
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für C++ effektive Formeigenschaften berechnet und anwendet, um eine präzise PowerPoint-Wiedergabe zu gewährleisten."
---

In diesem Thema besprechen wir **effective** und **local** Eigenschaften. Wenn wir Werte direkt auf diesen Ebenen setzen

1. In den Teil‑Eigenschaften auf der Folie des Teils.
1. Im Textstil der Prototyp‑Form auf Layout‑ oder Master‑Folie (falls die Textfeld‑Form des Teils einen hat).
1. In den globalen Texteinstellungen der Präsentation.

dann werden diese Werte **local** Werte genannt. Auf jeder Ebene können **local** Werte definiert oder weggelassen werden. Schließlich, wenn die Anwendung wissen muss, wie der Teil aussehen soll, verwendet sie **effective** Werte. Sie können **effective** Werte erhalten, indem Sie die Methode **GetEffective()** aus dem lokalen Format verwenden.

Das folgende Beispiel zeigt, wie man **effective** Werte erhält.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}

## **Effektive Eigenschaften einer Kamera abrufen**
Aspose.Slides für C++ ermöglicht Entwicklern, effektive Eigenschaften der Kamera zu erhalten. Zu diesem Zweck wurde die Klasse **CameraEffectiveData** in Aspose.Slides hinzugefügt. Die Klasse CameraEffectiveData stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz der Klasse **CameraEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein Paar effektiver Werte für die Klasse ThreeDFormat darstellt.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Kamera erhält.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **Effektive Eigenschaften eines Light Rig abrufen**
Aspose.Slides für C++ ermöglicht Entwicklern, effektive Eigenschaften des Light Rig zu erhalten. Zu diesem Zweck wurde die Klasse **LightRigEffectiveData** in Aspose.Slides hinzugefügt. Die Klasse LightRigEffectiveData stellt ein unveränderliches Objekt dar, das effektive Light‑Rig‑Eigenschaften enthält. Eine Instanz der Klasse **LightRigEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein Paar effektiver Werte für die Klasse ThreeDFormat darstellt.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für das Light Rig erhält.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **Effektive Eigenschaften einer Abschrägung (Bevel) abrufen**
Aspose.Slides für C++ ermöglicht Entwicklern, effektive Eigenschaften einer Abschrägung (Bevel) zu erhalten. Zu diesem Zweck wurde die Klasse **ShapeBevelEffectiveData** in Aspose.Slides hinzugefügt. Die Klasse ShapeBevelEffectiveData stellt ein unveränderliches Objekt dar, das effektive Eigenschaften der Formoberfläche enthält. Eine Instanz der Klasse **ShapeBevelEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein Paar effektiver Werte für die Klasse ThreeDFormat darstellt.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Abschrägung erhält.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **Effektive Eigenschaften eines Textfelds abrufen**
Mit Aspose.Slides für C++ können Sie effektive Eigenschaften eines Textfelds erhalten. Zu diesem Zweck wurde die Klasse **TextFrameFormatEffectiveData** in Aspose.Slides hinzugefügt, die effektive Formatierungseigenschaften des Textfelds enthält.

Das folgende Codebeispiel zeigt, wie man effektive Textfeld‑Formatierungseigenschaften erhält.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **Effektive Eigenschaften eines Textstils abrufen**
Mit Aspose.Slides für C++ können Sie effektive Eigenschaften eines Textstils erhalten. Zu diesem Zweck wurde die Klasse **TextStyleEffectiveData** in Aspose.Slides hinzugefügt, die effektive Texteigenschaften enthält.

Das folgende Codebeispiel zeigt, wie man effektive Texteigenschaften erhält.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **Den effektiven Schriftgrößenwert abrufen**
Mit Aspose.Slides für C++ können Sie effektive Eigenschaften der Schriftgröße erhalten. Hier ist ein Beispielcode, der zeigt, wie sich der effektive Schriftgrößenwert eines Abschnitts nach dem Setzen lokaler Schriftgrößenwerte auf unterschiedlichen Ebenen der Präsentationsstruktur ändert.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **Das effektive Füllformat für eine Tabelle abrufen**
Mit Aspose.Slides für C++ können Sie das effektive Füllformat für verschiedene logische Tabellenteile erhalten. Zu diesem Zweck wurde das Interface **IFillFormatEffectiveData** in Aspose.Slides hinzugefügt, das effektive Füllformat‑Eigenschaften enthält. Bitte beachten Sie, dass die Zellenformatierung immer höhere Priorität hat als die Zeilenformatierung, eine Zeile hat höhere Priorität als eine Spalte und eine Spalte hat höhere Priorität als die gesamte Tabelle.

Daher werden zum Rendern der Tabelle immer die **CellFormatEffectiveData**‑Eigenschaften verwendet. Das folgende Codebeispiel zeigt, wie man das effektive Füllformat für verschiedene tabellarische Logikteile erhält.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}

## **FAQ**

**Wie kann ich erkennen, ob ich einen „Snapshot“ und kein „Live‑Objekt“ erhalten habe, und wann sollte ich effektive Eigenschaften erneut auslesen?**

EffectiveData‑Objekte sind unveränderliche Snapshots der zum Aufrufzeitpunkt berechneten Werte. Wenn Sie lokale oder geerbte Einstellungen der Form ändern, rufen Sie die effektiven Daten erneut ab, um die aktualisierten Werte zu erhalten.

**Wirkt sich das Ändern von Layout‑ bzw. Master‑Folie auf bereits abgerufene effektive Eigenschaften aus?**

Ja, jedoch erst, nachdem Sie sie erneut gelesen haben. Ein bereits erhaltenes EffectiveData‑Objekt aktualisiert sich nicht selbst — fordern Sie es nach einer Änderung des Layouts oder Masters erneut an.

**Kann ich Werte über EffectiveData ändern?**

Nein. EffectiveData ist schreibgeschützt. Änderungen erfolgen in den lokalen Formatierungsobjekten (Form/Text/3D usw.), anschließend können Sie die effektiven Werte erneut abrufen.

**Was passiert, wenn eine Eigenschaft weder auf Form‑Ebene, noch im Layout/Master, noch in den globalen Einstellungen gesetzt ist?**

Der effektive Wert wird durch den Standardmechanismus (PowerPoint/Aspose.Slides‑Standardwerte) bestimmt. Dieser aufgelöste Wert wird Teil des EffectiveData‑Snapshots.

**Kann ich anhand eines effektiven Schriftwerts erkennen, welche Ebene die Größe oder Schriftart bereitgestellt hat?**

Nicht direkt. EffectiveData liefert nur den endgültigen Wert. Um die Quelle zu ermitteln, prüfen Sie die lokalen Werte auf Abschnitt/Ebene/Textfeld‑Ebene sowie die Textstile im Layout/Master/Präsentation, um die erste explizite Definition zu finden.

**Warum sehen EffectiveData‑Werte manchmal identisch mit den lokalen aus?**

Weil der lokale Wert letztlich final war (keine höhere Ebene musste vererbt werden). In solchen Fällen stimmt der effektive Wert mit dem lokalen überein.

**Wann sollte ich effektive Eigenschaften verwenden und wann nur mit lokalen arbeiten?**

Verwenden Sie EffectiveData, wenn Sie das „wie gerenderte“ Ergebnis nach vollständiger Vererbung benötigen (z. B. zum Angleichen von Farben, Einzügen oder Größen). Wenn Sie Formatierungen auf einer bestimmten Ebene ändern wollen, passen Sie die lokalen Eigenschaften an und lesen Sie bei Bedarf EffectiveData erneut, um das Ergebnis zu überprüfen.