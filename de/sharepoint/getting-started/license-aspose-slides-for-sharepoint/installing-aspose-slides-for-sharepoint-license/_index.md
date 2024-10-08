---
title: Installation der Aspose.Slides für SharePoint-Lizenz
type: docs
weight: 10
url: /de/sharepoint/installing-aspose-slides-for-sharepoint-license/
---

{{% alert color="primary" %}} 

Sobald Sie mit Ihrer Evaluierung zufrieden sind, können Sie eine [Lizenz kaufen](https://purchase.aspose.com/buy). Stellen Sie vor dem Kauf sicher, dass Sie die Bedingungen des Lizenzabonnements verstehen und akzeptieren. Die Lizenz wird Ihnen per E-Mail zugesandt, sobald die Bestellung bezahlt wurde.

Die Lizenz ist eine ZIP-Datei, die ein reguläres SharePoint-Lösungs-Paket enthält. Die Archive enthalten:

- Aspose.Slides.SharePoint.License.wsp – die SharePoint-Lösungs-Paketdatei. Die Lizenz ist als SharePoint-Lösung verpackt, um die Bereitstellung und Rücknahme über eine Serverfarm zu erleichtern.
- readme.txt – Lizenzinstallationsanleitungen.

{{% /alert %}} 
## **Bereitstellung der Lizenz**
Die Lizenzinstallation erfolgt über die Serverkonsole mittels **stsadm.exe**.

{{% alert color="primary" %}} 

Die Pfade werden im folgenden Abschnitt der Klarheit halber weggelassen.

{{% /alert %}} 

Führen Sie die folgenden Schritte aus, um die Aspose.Slides für SharePoint-Lizenz bereitzustellen:

1. Führen Sie stsadm aus, um die Lösung im SharePoint-Lösungs-Store hinzuzufügen: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Stellen Sie die Lösung auf allen Servern in der Farm bereit: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Führen Sie administrative Timer-Jobs aus, um die Bereitstellung sofort abzuschließen: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

Sie erhalten eine Warnung, wenn Sie den Bereitstellungsschritt ausführen, wenn der Windows SharePoint-Dienste-Administrationsdienst nicht ausgeführt wird. **stsadm.exe** ist auf diesen Dienst und den Windows SharePoint Timer-Dienst angewiesen, um Lösungsdaten über die Farm zu replizieren. Wenn diese Dienste nicht auf Ihrer Serverfarm ausgeführt werden, müssen Sie die Lizenz auf jedem Server bereitstellen. 

{{% /alert %}} 
## **Testen der Lizenz**
Um zu testen, ob die Lizenz korrekt installiert wurde, konvertieren Sie ein beliebiges Dokument in ein neues Format. Wenn das Dokument kein Evaluierungs-Wasserzeichen enthält, wurde die Lizenz erfolgreich aktiviert. 