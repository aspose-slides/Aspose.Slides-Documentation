---  
title: Metered-Lizenzierung  
type: docs  
weight: 90  
url: /de/net/metered-licensing/  
---  

{{% alert color="primary" %}}  

Die Metered-Lizenzierung ist ein neuer Lizenzierungsmechanismus, der zusammen mit bestehenden Lizenzierungsmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides API-Funktionen abgerechnet werden möchten, wählen Sie die Metered-Lizenzierung.  

Beim Kauf einer Metered-Lizenz erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser Metered-Schlüssel kann mit der von Aspose bereitgestellten [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) Klasse für Abrechnungsoperationen angewendet werden. Weitere Details finden Sie in den [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).  

{{% /alert %}}  

1. Erstellen Sie eine Instanz der [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) Klasse.  
1. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/) Methode.  
1. Führen Sie einige Verarbeitungen durch (stellen Sie Aufgaben aus).  
1. Rufen Sie die [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) Methode der Metered-Klasse auf.  

   Sie sollten die Menge/Anzahl der API-Anfragen sehen, die Sie bisher konsumiert haben.  

Dieser C#-Code zeigt Ihnen, wie Sie die Metered-öffentlichen und privaten Schlüssel setzen:  

```c#  
//  Erstellt eine Instanz der Metered-Klasse  
	Aspose.Slides.Metered metered = new Aspose.Slides.Metered();  

//  Greift auf die SetMeteredKey-Eigenschaft zu und übergibt die öffentlichen und privaten Schlüssel als Parameter  
	metered.SetMeteredKey("*****", "*****");  

//  Holt die Menge an abgerechneten Daten vor dem API-Aufruf  
	decimal amountbefore = Aspose.Slides.Metered.GetConsumptionQuantity();  

//  Gibt die Informationen aus  
	Console.WriteLine("Vorher konsumierte Menge: " + amountbefore.ToString());  

//  Holt die Menge an abgerechneten Daten nach dem API-Aufruf  
	decimal amountafter = Aspose.Slides.Metered.GetConsumptionQuantity();  

//  Gibt die Informationen aus  
	Console.WriteLine("Nachher konsumierte Menge: " + amountafter.ToString());  
```  

{{% alert color="warning" title="HINWEIS"  %}}  

Um die Metered-Lizenzierung zu verwenden, benötigen Sie eine stabile Internetverbindung, da der Lizenzierungsmechanismus das Internet nutzt, um ständig mit unseren Diensten zu interagieren und Berechnungen durchzuführen.  

{{% /alert %}}  