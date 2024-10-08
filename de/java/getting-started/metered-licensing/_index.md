---  
title: Metered-Lizenzierung  
type: docs  
weight: 100  
url: /de/java/metered-licensing/  
---  

{{% alert color="primary" %}}  

Die metered Lizenzierung ist ein neues Lizenzierungssystem, das zusammen mit bestehenden Lizenzierungsmethoden verwendet werden kann. Wenn Sie basierend auf Ihrer Nutzung der Aspose.Slides API-Funktionen abgerechnet werden möchten, wählen Sie die metered Lizenzierung.  

Wenn Sie eine metered Lizenz erwerben, erhalten Sie Schlüssel (und keine Lizenzdatei). Dieser metered Schlüssel kann mit der von Aspose bereitgestellten [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) Klasse für Messoperationen angewendet werden. Für weitere Details siehe [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).  

{{% /alert %}}  
1. Erstellen Sie eine Instanz der [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) Klasse.  

1. Übergeben Sie Ihre öffentlichen und privaten Schlüssel an die [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) Methode.  

1. Führen Sie einige Verarbeitungen durch (erledigen Sie Aufgaben).  

1. Rufen Sie die [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) Methode der Metered-Klasse auf.  

   Sie sollten die Menge/Anzahl der API-Anfragen sehen, die Sie bisher konsumiert haben.  

Dieser Java-Code zeigt Ihnen, wie Sie metered öffentliche und private Schlüssel setzen:  

```java  
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();  
try {  
    // Greift auf die setMeteredKey-Eigenschaft zu und übergibt öffentliche und private Schlüssel als Parameter  
    metered.setMeteredKey("<gültiger öffentlicher Schlüssel>", "<gültiger privater Schlüssel>");  

    // Holt den Verbrauchswert vor dem Zugriff auf die API  
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();  
    System.out.println("Verbrauchsmenge" + quantityOld);  

    // Holt den Verbrauchswert nach dem Zugriff auf die API  
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();  
    System.out.println("Verbrauchsmenge" + quantity);  
} catch (Exception ex) {  
    ex.printStackTrace();  
}  
```  

{{% alert color="warning" title="HINWEIS"  %}}  

Um die metered Lizenzierung zu verwenden, benötigen Sie eine stabile Internetverbindung, da das Lizenzierungssystem das Internet nutzt, um ständig mit unseren Dienstleistungen zu interagieren und Berechnungen durchzuführen.  

{{% /alert %}}  