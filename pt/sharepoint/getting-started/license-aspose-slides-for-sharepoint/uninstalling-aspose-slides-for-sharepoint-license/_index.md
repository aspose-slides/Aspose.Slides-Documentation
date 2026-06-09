---
title: Desinstalando a Licença Aspose.Slides para SharePoint
type: docs
weight: 20
url: /pt/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
Para desinstalar a licença, use as etapas abaixo a partir do console do servidor. 

1. Retire a solução de licença da fazenda: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Execute trabalhos de timer administrativos para concluir a retirada imediatamente: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Aguarde a conclusão da retirada. Você pode usar a Central Administration para verificar se a retirada foi concluída em **Central Administration**, depois em **Operations** e **Solution Management**.
4. Remova a solução do repositório de soluções do SharePoint: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```