---
title: Instalando a licença Aspose.Slides para SharePoint
type: docs
weight: 10
url: /pt/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Instale a licença Aspose.Slides para SharePoint em uma fazenda SharePoint: adicione a solução de licença ao repositório de soluções, implante-a e verifique se os arquivos convertidos não apresentam mais a marca d'água de avaliação."
---
{{% alert color="info" title="Note" %}}

Uma vez que você esteja satisfeito com sua avaliação, pode [adquirir uma licença](https://purchase.aspose.com/pricing/slides/sharepoint/). Antes de comprar, certifique‑se de que entende e aceita os termos de assinatura da licença. A licença é enviada por e‑mail para você quando o pedido for pago.

A licença é um arquivo ZIP que contém um pacote de solução SharePoint padrão. O arquivo contém:

- Aspose.Slides.SharePoint.License.wsp – o arquivo do pacote de solução SharePoint. A licença é empacotada como uma solução SharePoint para facilitar a implantação e a retirada em uma fazenda de servidores.
- readme.txt – instruções de instalação da licença.

{{% /alert %}}

## **Implantando a Licença**

A instalação da licença é realizada a partir do console do servidor via **stsadm.exe**.

{{% alert color="info" title="Note" %}}

Os caminhos foram omitidos na seção a seguir para maior clareza.

{{% /alert %}}

Execute as etapas a seguir para implantar a licença Aspose.Slides para SharePoint:

1. Execute stsadm para adicionar a solução ao repositório de soluções SharePoint:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Implante a solução em todos os servidores da fazenda:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Execute trabalhos de timer administrativos para concluir a implantação imediatamente:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

A operação `addsolution` recebe o caminho do arquivo da solução em `-filename`; a operação `deploysolution` recebe o nome da solução que já está no repositório de soluções em `-name`.

{{% alert color="info" title="Note" %}}

Você receberá um aviso ao executar a etapa de implantação se o serviço de Administração do SharePoint não estiver em execução. **stsadm.exe** depende desse serviço e do serviço Timer do SharePoint para replicar os dados da solução em toda a fazenda. Se esses serviços não estiverem em execução na sua fazenda de servidores, talvez seja necessário implantar a licença em cada servidor.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

No SharePoint 2010 e versões posteriores, os cmdlets do SharePoint Management Shell `Add-SPSolution`, `Install-SPSolution` e `Start-SPAdminJob` correspondem às operações `addsolution`, `deploysolution` e `execadmsvcjobs`. Veja [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Testar a Licença**

Para testar se a licença foi instalada corretamente, converta qualquer apresentação para um novo formato. Se não houver marca d'água de avaliação no arquivo convertido, a licença está ativa.