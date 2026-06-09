---
title: Instalação
type: docs
weight: 70
url: /pt/cpp/installation/
keywords:
- instalar Aspose.Slides
- baixar Aspose.Slides
- usar Aspose.Slides
- instalação do Aspose.Slides
- Windows
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como instalar rapidamente o Aspose.Slides para C++. Guia passo a passo, requisitos de sistema e exemplos de código — comece a trabalhar com apresentações PowerPoint hoje!"
---
## **Visão geral**

Este artigo explica como instalar o Aspose.Slides no Windows. Ele foca na instalação baseada em NuGet e mostra como adicionar a biblioteca a um projeto do Visual Studio, seja pelo Gerenciador de Pacotes NuGet ou pelo Console do Gerenciador de Pacotes no Windows. Também descreve como atualizar o pacote e instalar compilações pré‑release quando necessário.

## **Windows**
NuGet fornece o caminho mais fácil para baixar e instalar as APIs Aspose para C++ em PCs. 

### **Opção Um: Instalar ou Atualizar Aspose.Slides para C++ a partir do Gerenciador de Pacotes NuGet**

1. Abra o Microsoft Visual Studio. 
2. Crie um aplicativo console simples. Ou abra seu projeto preferido. 
3. Acesse **Tools** > **NuGet package manager**.
4. Em **Browse**, digite *Aspose.Slides.Cpp* no campo de texto. 

![todo:image_alt_text](installation_1.png)

3. Clique na versão que você precisa **Aspose.Slides.Cpp** e depois clique em **Install**. 
   * Se quiser atualizar o Aspose.Slides—ou seja, já o tem instalado—clique em **Update** em vez disso. 

A API selecionada é baixada e referenciada no seu projeto.

### **Opção 2: Instalar ou Atualizar Aspose.Slides através do Console do Gerenciador de Pacotes**

Para referenciar a [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) usando o console do gerenciador de pacotes, faça o seguinte:

1. Abra sua solução/projeto no Visual Studio.

1. Acesse **Tools** > **NuGet Package Manager** > **Package Manager Console**. 

   O Console do Gerenciador de Pacotes será aberto. 

![todo:image_alt_text](installation_2.png)

4. Digite este comando: `Install-Package Aspose.Slides.Cpp` 
> Se quiser instalar a versão x86, use o pacote Aspose.Slides.Cpp.x86: `Install-Package Aspose.Slides.Cpp.x86`

5. Pressione a tecla Enter.

   A versão mais recente completa será instalada em sua aplicação. 

   * Como alternativa, você pode acrescentar o sufixo `-prerelease` ao comando para especificar que a versão mais recente (incluindo hotfixes) também deve ser instalada.

![todo:image_alt_text](installation_3.png)

​	Quando o download for concluído, você deverá ver algumas mensagens de confirmação.  

![todo:image_alt_text](installation_4.png)

Se você não estiver familiarizado com a [Aspose EULA](https://about.aspose.com/legal/eula), pode querer ler a licença referenciada no URL.  

No Console do Gerenciador de Pacotes, você pode executar o comando `Update-Package Aspose.Slides.Cpp` para verificar atualizações do pacote Aspose.Slides. Atualizações (se encontradas) são instaladas automaticamente. Você também pode usar o sufixo `-prerelease` para atualizar a versão mais recente.

### **Usando as pastas Include e lib**
1. [Download](https://downloads.aspose.com/slides/pt/cpp) a versão mais recente do Aspose.Slides para C++.
1. Descompacte a pasta no ambiente de produção.
1. Para usar o Aspose.Slides para C++, faça referência às pastas Include e lib em seu projeto

## **FAQ**

**Existe uma versão gratuita ou limitação de avaliação?**

Sim, por padrão, o Aspose.Slides funciona em modo de avaliação, o que adiciona marcas d'água e pode ter outras limitações. Para remover as restrições, você precisa aplicar uma [licença](/slides/pt/cpp/licensing/).