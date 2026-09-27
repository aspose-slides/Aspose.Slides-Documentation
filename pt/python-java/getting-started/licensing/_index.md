---
title: Licenciamento
type: docs
weight: 80
url: /pt/python-java/licensing/
keywords:
- Aspose.Slides
- Python
- Java
- arquivo de licença
- licença temporária
- licenciamento por medição
- limitações de avaliação
description: "Aplique uma licença de arquivo, baseada em bytes ou por medição no Aspose.Slides for Python via Java e remova as limitações de avaliação de suas aplicações."
---
## **Visão geral**

Aspose.Slides for Python via Java pode ser executado no modo de avaliação ou com uma licença. No modo de avaliação, ele adiciona uma caixa de texto de marca d'água de avaliação a cada slide de cada apresentação que salva e trunca o texto que seu código lê das apresentações. Este artigo explica como aplicar uma licença a partir de um arquivo ou de bytes e como configurar a licença por medição.

Para opções de compra, veja [Pricing Information](https://purchase.aspose.com/pricing/slides/pt/family). Para perguntas gerais sobre licenciamento e compras, veja [Purchase Policies and FAQ](https://purchase.aspose.com/policies).

Para limitações de avaliação e como solicitar uma licença temporária, veja [Evaluate Aspose.Slides](/slides/pt/python-java/evaluate-aspose-slides/). Aplique uma licença temporária da mesma forma que um arquivo de licença adquirido.

## **Sobre a licença**

Um arquivo de licença contém informações como o nome do produto, o número de desenvolvedores licenciados e a data de expiração da assinatura. O arquivo é XML assinado digitalmente.

{{% alert color="warning" title="Warning" %}}
Não edite o arquivo de licença. Mesmo uma quebra de linha extra pode invalidar sua assinatura digital.
{{% /alert %}}

Aplique a licença uma vez por aplicação ou processo, antes de criar apresentações ou executar outras operações do Aspose.Slides. Para um arquivo de licença, use a classe [License](https://reference.aspose.com/slides/pt/python-java/aspose.slides/license/). A licença por medição usa um par de chaves pública e privada em vez de um arquivo de licença.

## **Aplicar uma licença**

Os exemplos a seguir presumem que Aspose.Slides for Python via Java e seus pré‑requisitos estão instalados. Cada exemplo é um script autônomo que inicia a JVM, importa a API e aplica uma licença. Em sua aplicação, execute as operações de apresentação após aplicar a licença e desligue a JVM somente depois que todo o trabalho do Aspose.Slides estiver concluído.

### **Aplicar uma licença a partir de um arquivo**

Passe o caminho do arquivo de licença para [License.setLicense](https://reference.aspose.com/slides/pt/python-java/aspose.slides/license/#setLicense). Substitua `Aspose.Slides.lic` pelo caminho do seu arquivo de licença.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        license = License()
        license.setLicense(str(license_path))
        print("Licensed:", license.isLicensed())
        # Execute as operações de apresentação aqui, antes de encerrar a JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Use o nome exato do arquivo, incluindo sua extensão. Por exemplo, se o arquivo for chamado `Aspose.Slides.lic.xml`, inclua `.xml` no caminho. Um caminho absoluto evita ambiguidades sobre o diretório de trabalho da aplicação.

O exemplo usa [License.isLicensed](https://reference.aspose.com/slides/pt/python-java/aspose.slides/license/#isLicensed) para verificar se a licença foi aplicada.

### **Aplicar uma licença a partir de bytes**

Use [License.setLicenseFromBytes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/license/#setLicenseFromBytes) quando a licença estiver disponível como bytes em Python. O exemplo a seguir lê o arquivo em modo binário e o fecha antes de aplicar a licença.

```python
from pathlib import Path

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import License

    license_path = Path("Aspose.Slides.lic")
    if license_path.is_file():
        with license_path.open("rb") as license_file:
            license_data = license_file.read()

        license = License()
        license.setLicenseFromBytes(license_data)
        print("Licensed:", license.isLicensed())
        # Execute as operações de apresentação aqui, antes de encerrar a JVM.
    else:
        print("License file not found. Set the path to your license file.")
finally:
    jpype.shutdownJVM()
```

Mantenha os bytes originais inalterados. Não decodifique, reformatte ou modifique de outra forma o conteúdo da licença antes de aplicá‑la.

## **Aplicar uma licença por medição**

A licença por medição cobra você de acordo com o uso da API. Depois de obter uma licença por medição, aplique suas chaves pública e privada com [Metered.setMeteredKey](https://reference.aspose.com/slides/pt/python-java/aspose.slides/metered/#setMeteredKey). Inicialize o objeto [Metered](https://reference.aspose.com/slides/pt/python-java/aspose.slides/metered/) e aplique as chaves uma vez na inicialização da aplicação.

O exemplo a seguir lê as chaves das variáveis de ambiente `ASPOSE_METERED_PUBLIC_KEY` e `ASPOSE_METERED_PRIVATE_KEY`. Defina ambas as variáveis antes de executar o script.

```python
import os

import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Metered

    public_key = os.environ.get("ASPOSE_METERED_PUBLIC_KEY")
    private_key = os.environ.get("ASPOSE_METERED_PRIVATE_KEY")

    if public_key and private_key:
        metered = Metered()
        metered.setMeteredKey(public_key, private_key)
        # Execute as operações de apresentação aqui, antes de encerrar a JVM.
    else:
        print("Set both metered licensing environment variables before running this example.")
finally:
    jpype.shutdownJVM()
```

{{% alert color="info" title="Note" %}}
A licença por medição requer uma conexão à Internet para validar as chaves e relatar o uso. Mantenha a chave privada fora do código‑fonte e dos logs. Veja a [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) para detalhes sobre conectividade e faturamento.
{{% /alert %}}

## **FAQ**

**Do I need to install a different package after purchasing a license?**

Não. Aplique a licença ao mesmo pacote que você usou na avaliação.

**Should I apply a license for every presentation?**

Não. Aplique‑a uma vez durante a inicialização da aplicação, antes de criar ou carregar apresentações.

**Can I rename the license file?**

Sim. Use o nome exato do novo arquivo em seu código e mantenha o conteúdo do arquivo inalterado.

**Can I use a temporary license with the byte-based example?**

Sim. Leia o arquivo de licença temporária como bytes e aplique‑o da mesma forma que uma licença comprada.