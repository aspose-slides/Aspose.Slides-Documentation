---
title: Effektive Eigenschaften von Formen
type: docs
weight: 50
url: /cpp/shape-effective-properties/
---


In diesem Thema werden wir **effektive** und **lokale** Eigenschaften diskutieren. Wenn wir Werte direkt auf diesen Ebenen festlegen

1. In Abschnittseigenschaften auf der Folie des Abschnitts.
1. In den Textstil der Prototypform auf der Layout- oder Masterfolie (wenn die Textrahmenform des Abschnitts eine hat).
1. In den globalen Texteinstellungen der Präsentation.

dann werden diese Werte als **lokale** Werte bezeichnet. Auf jeder Ebene können **lokale** Werte definiert oder weggelassen werden. Aber letztendlich, wenn es darauf ankommt, dass die Anwendung wissen muss, wie der Abschnitt aussehen soll, verwendet sie **effektive** Werte. Sie können effektive Werte mit der **GetEffective()**-Methode aus dem lokalen Format erhalten.

Das folgende Beispiel zeigt, wie man effektive Werte erhält.



{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValues-GetEffectiveValues.cpp" >}}


## **Effektive Eigenschaften der Kamera abrufen**
Aspose.Slides für C++ ermöglicht Entwicklern, die effektiven Eigenschaften der Kamera abzurufen. Zu diesem Zweck wurde die Klasse **CameraEffectiveData** in Aspose.Slides hinzugefügt. Die Klasse CameraEffectiveData stellt ein unveränderliches Objekt dar, das effektive Kameraeigenschaften enthält. Eine Instanz der Klasse **CameraEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein effektives Wertepaar für die Klasse ThreeDFormat ist.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Kamera abruft.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetCameraEffectiveData-GetCameraEffectiveData.cpp" >}}

## **Effektive Eigenschaften des Lichtsets abrufen**
Aspose.Slides für C++ ermöglicht Entwicklern, die effektiven Eigenschaften des Lichtsets abzurufen. Zu diesem Zweck wurde die Klasse **LightRigEffectiveData** in Aspose.Slides hinzugefügt. Die Klasse LightRigEffectiveData stellt ein unveränderliches Objekt dar, das effektive Eigenschaften des Lichtsets enthält. Eine Instanz der Klasse **LightRigEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein effektives Wertepaar für die Klasse ThreeDFormat ist.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für das Lichtset abruft.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetLightRigEffectiveData-GetLightRigEffectiveData.cpp" >}}

## **Effektive Eigenschaften der Fasenform abrufen**
Aspose.Slides für C++ ermöglicht Entwicklern, die effektiven Eigenschaften der Fasenform abzurufen. Zu diesem Zweck wurde die Klasse **ShapeBevelEffectiveData** in Aspose.Slides hinzugefügt. Die Klasse ShapeBevelEffectiveData stellt ein unveränderliches Objekt dar, das die effektiven Relief-Eigenschaften der Form enthält. Eine Instanz der Klasse **ShapeBevelEffectiveData** wird als Teil der Klasse **ThreeDFormatEffectiveData** verwendet, die ein effektives Wertepaar für die Klasse ThreeDFormat ist.

Das folgende Codebeispiel zeigt, wie man effektive Eigenschaften für die Fasenform abruft.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetShapeBevelEffectiveData-GetShapeBevelEffectiveData.cpp" >}}

## **Effektive Eigenschaften des Textrahmens abrufen**
Mit Aspose.Slides für C++ können Sie die effektiven Eigenschaften des Textrahmens abrufen. Zu diesem Zweck wurde die Klasse **TextFrameFormatEffectiveData** in Aspose.Slides hinzugefügt, die die effektiven Formatierungseigenschaften des Textrahmens enthält.

Das folgende Codebeispiel zeigt, wie man die effektiven Formatierungseigenschaften des Textrahmens abruft.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextFrameFormatEffectiveData-GetTextFrameFormatEffectiveData.cpp" >}}

## **Effektive Eigenschaften des Textstils abrufen**
Mit Aspose.Slides für C++ können Sie die effektiven Eigenschaften des Textstils abrufen. Zu diesem Zweck wurde die Klasse **TextStyleEffectiveData** in Aspose.Slides hinzugefügt, die die effektiven Eigenschaften des Textstils enthält.

Das folgende Codebeispiel zeigt, wie man die effektiven Eigenschaften des Textstils abruft.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetTextStyleEffectiveData-GetTextStyleEffectiveData.cpp" >}}

## **Effektiven Schriftgradwert abrufen**
Mit Aspose.Slides für C++ können Sie die effektiven Eigenschaften des Schriftgrads abrufen. Hier ist der Code, der demonstriert, wie sich der effektive Schriftgradwert des Abschnitts ändert, nachdem lokale Schriftgradwerte auf verschiedenen Präsentationsstruktur-Ebenen festgelegt wurden.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLocalFontHeightValues-SetLocalFontHeightValues.cpp" >}}

## **Effektives Füllformat für Tabellen abrufen**
Mit Aspose.Slides für C++ können Sie das effektive Füllformat für verschiedene logische Teile von Tabellen abrufen. Zu diesem Zweck wurde das Interface **IFillFormatEffectiveData** in Aspose.Slides hinzugefügt, das die effektiven Füllformatierungseigenschaften enthält. Bitte beachten Sie, dass die Zellformatierung immer eine höhere Priorität hat als die Zeilenformatierung, eine Zeile eine höhere Priorität als eine Spalte und eine Spalte eine höhere Priorität als die gesamte Tabelle hat.

Daher werden schließlich die Eigenschaften von **CellFormatEffectiveData** immer verwendet, um die Tabelle zu zeichnen. Das folgende Codebeispiel zeigt, wie man die effektive Füllformatierung für verschiedene logische Teile von Tabellen abruft.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-GetEffectiveValuesOfTable-GetEffectiveValuesOfTable.cpp" >}}