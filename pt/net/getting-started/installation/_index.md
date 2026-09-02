---
title: Instalação
type: docs
weight: 70
url: /pt/net/installation/
keywords:
- instalar Aspose.Slides
- baixar Aspose.Slides
- usar Aspose.Slides
- instalação Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Saiba como instalar rapidamente o Aspose.Slides para .NET. Guia passo a passo, requisitos de sistema e exemplos de código — comece a trabalhar com apresentações PowerPoint hoje!"
---
## **Visão geral**

Este artigo explica como instalar o Aspose.Slides para .NET no Windows, Linux e macOS. Ele se concentra na instalação baseada em NuGet e mostra como adicionar a biblioteca através do NuGet Package Manager ou do Package Manager Console no Windows, em um projeto .NET no Linux e em um projeto Visual Studio no macOS. Também descreve como atualizar o pacote e instalar builds pré‑release quando necessário.

Antes da instalação, revise os sistemas operacionais suportados, as implementações .NET e as dependências adicionais em [Requisitos de Sistema](/slides/pt/net/system-requirements/).

## **Windows**
O NuGet oferece o caminho mais fácil para baixar e instalar APIs Aspose para .NET em PCs. 

### **Método 1: Instalar ou Atualizar Aspose.Slides a partir do NuGet Package Manager**

1. Abra o Microsoft Visual Studio. 
2. Crie um aplicativo console simples ou abra um projeto existente. 
3. Navegue até **Tools** > **NuGet package manager**.
4. Em **Browse**, procure por *Aspose Slides* no campo de texto. 
{{% image img="installation_1.png" alt="Aspose.Slides Installation from NuGet Package Manager - 1" %}}
5. Clique em **Aspose.Slides.NET** e depois em **Install**. 
   * Se quiser atualizar o Aspose.Slides — assumindo que já o instalou — clique em **Update** em vez disso. 

A API selecionada é baixada e referenciada no seu projeto.

### **Método 2: Instalar ou Atualizar Aspose.Slides através do Package Manager Console**

Esta é a forma de referenciar a [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) através do console do gerenciador de pacotes:

1. Abra o Microsoft Visual Studio. 
2. Crie um aplicativo console simples ou abra um projeto existente. 
3. Navegue até **Tools** > **Library Package Manager** > **Package Manager Console**. 
![todo:image_alt_text](installation_2.png)
4. Execute este comando: `Install-Package Aspose.Slides.NET` 
![todo:image_alt_text](installation_3.png)
A última versão completa é instalada em sua aplicação. 

* Alternativamente, você pode adicionar o sufixo `-prerelease` ao comando para especificar que a versão mais recente (incluindo hotfixes) também deve ser instalada.

 A dica **Installing Aspose.Slides.NET** aparece próximo à parte inferior da janela. 
![todo:image_alt_text](installation_4.png)

Quando o download for concluído, você deverá ver algumas mensagens de confirmação. 

Se você não está familiarizado com a [Aspose EULA](https://about.aspose.com/legal/eula), pode desejar ler a licença referenciada na URL. 
![todo:image_alt_text](installation_5.png)

Em sua aplicação, você deverá ver que o Aspose.Slides foi adicionado e referenciado com sucesso. 
![todo:image_alt_text](installation_6.png)

No Package Manager Console, você pode executar o comando `Update-Package Aspose.Slides.NET` para verificar atualizações do pacote Aspose.Slides. Atualizações (se encontradas) são instaladas automaticamente. Você também pode usar o sufixo `-prerelease` para atualizar a versão mais recente.

#### **Considerações ao Executar em um Ambiente de Servidor Compartilhado**
Recomendamos fortemente que você execute todos os componentes Aspose .NET com o conjunto de permissões **Full Trust**, pois os componentes Aspose às vezes precisam acessar configurações do registro e arquivos localizados em locais diferentes do diretório virtual — por exemplo, quando os componentes Aspose precisam ler fontes. 

Além disso, os componentes Aspose.NET são baseados nas classes principais do sistema .NET — e algumas dessas classes também requerem permissão Full Trust para operações em determinados casos.

Os provedores de serviços de Internet, que hospedam múltiplas aplicações de diferentes empresas, geralmente aplicam o nível de segurança Medium Trust. No caso do .NET 2.0, esse nível de segurança pode gerar restrições que afetam as operações do Aspose.Slides:

- **RegistryPermission** não está disponível. Isso significa que você não pode acessar o registro, o que é necessário para enumerar fontes instaladas ao renderizar documentos.
- **FileIOPermission** está restrito. Isso significa que você só pode acessar arquivos na hierarquia do diretório virtual da sua aplicação. Isso também pode implicar que fontes não podem ser lidas durante operações de exportação. 

Por essas razões, recomendamos fortemente que você execute o Aspose.Slides com permissões **Full Trust**. Se você usar **Medium trust**, pode enfrentar inconsistências — alguns recursos da biblioteca (renderização, por exemplo) podem não funcionar ao executar determinadas tarefas. 

## **Linux**

O NuGet oferece o caminho mais fácil para baixar e instalar o Aspose.Slides para .NET no Linux. Adicione o pacote [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) ao seu projeto .NET.

## **macOS**

O NuGet oferece o caminho mais fácil para baixar e instalar o Aspose.Slides para .NET em Macs.

### **Instalar Aspose.Slides**

1. Abra o Visual Studio. 
2. Crie um aplicativo console simples ou abra um projeto existente.
3. Navegue até **Project** > **Manage NuGet Packages...**
   ![path-to-nuget-macos](path-to-nuget-macos.png)
4. Digite *Aspose.Slides* no campo de texto. 
5. Clique em **Aspose.Slides for .NET** e depois em **Add Package**. 
6. Adicione um trecho de código simples.
   * Você pode copiar o código nesta [página](/slides/pt/net/create-presentation/).
7. Execute o aplicativo.
8. Abra *folder/bin/Debug/presentation_file_name* do seu projeto.

## **FAQ**

**Existe uma versão gratuita ou limitação de avaliação?**

Sim, por padrão, o Aspose.Slides roda em modo de avaliação, o que adiciona marcas d'água e pode ter outras limitações. Para remover as restrições, você precisa aplicar uma [licença](/slides/pt/net/licensing/) válida.