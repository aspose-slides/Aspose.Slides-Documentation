---
title: Instalação
type: docs
weight: 70
url: /pt/python-net/installation/
keywords:
- baixar Aspose.Slides
- instalar Aspose.Slides
- usar Aspose.Slides
- instalação Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Instale Aspose.Slides para Python via .NET a partir do PyPI com pip no Windows, Linux e macOS, e instale as bibliotecas nativas que o Linux e o macOS precisam."
---
## **Visão geral**

Este artigo explica como instalar o Aspose.Slides para Python via .NET no Windows, Linux e macOS. O pacote é publicado no [PyPI](https://pypi.org/project/aspose.slides/) e instalado com pip. Ele inclui o runtime .NET que utiliza, portanto você não precisa instalar o .NET. No Linux e macOS, esse runtime precisa de bibliotecas nativas que o sistema operacional pode não incluir; as seções abaixo as nomeiam.

O Aspose.Slides para Python via .NET suporta Python 3.5 a 3.14. O PyPI fornece pacotes para Windows (32 bits e 64 bits), Linux (x86_64 e ARM64) e macOS (Intel e Apple silicon).

## **Windows**

No Windows, instale o pacote com pip. Nenhuma outra biblioteca é necessária.

```bash
pip install aspose.slides
```

## **Linux**

No Linux, o runtime .NET incluído no pacote precisa de duas bibliotecas:

- **libgdiplus**, uma implementação da API gráfica Windows GDI+. Sem ela, salvar uma apresentação falha com o erro `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Sem ela, o processo Python termina na primeira chamada ao Aspose.Slides com a mensagem `Couldn't find a valid ICU package installed on the system`.

No Debian e Ubuntu, instale ambos com apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

O nome do pacote ICU contém sua versão: `libicu76` é o pacote para Debian 13. No Debian 12, instale `libicu72` e, no Ubuntu 24.04, `libicu74`. Para encontrar o nome no seu sistema, execute:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Em seguida, instale o pacote em um ambiente virtual. Nas versões atuais do Debian e Ubuntu, o Python do sistema não permite `pip install` fora de um ambiente virtual e interrompe com o erro `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Execute seus scripts com o mesmo ambiente virtual ativado. Se você usar um Python que sua distribuição não gerencia, como o das imagens oficiais `python` Docker, também pode executar `pip install aspose.slides` sem um ambiente virtual.

As fontes usadas em suas apresentações, ou substitutos adequados, devem estar instaladas no sistema para que o texto seja renderizado corretamente ao converter slides para PDF ou imagens.

## **macOS**

Não verificamos a instalação no macOS. No macOS, o Aspose.Slides precisa dos seguintes pré-requisitos:

- **Python com bibliotecas compartilhadas**, ou seja, Python compilado com a opção de configuração `--enable-shared`. Se você instalar o Python com [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos), defina a variável de ambiente `PYTHON_CONFIGURE_OPTS` para `--enable-shared` ao instalar uma versão do Python.
- **A biblioteca libpython em um diretório de bibliotecas do sistema.** Um Python instalado com pyenv mantém sua biblioteca libpython, como *libpython3.9.dylib*, em *~/.pyenv/versions*; crie um link simbólico para ela em */usr/local/lib*.
- **libgdiplus**, uma implementação da API gráfica Windows GDI+. O Homebrew a fornece como o pacote `mono-libgdiplus`.

Em seguida, instale o pacote com pip.

## **Verificar a instalação**

Para verificar a instalação, salve o primeiro exemplo em [Create Presentations](/slides/pt/python-net/create-presentation/) como *hello.py* e execute `python hello.py`. Ele salva *new_presentation.pptx* na pasta atual.

## **Atualização**

Para atualizar uma instalação existente para a versão mais recente, execute este comando no ambiente onde você instalou o pacote:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Posso instalar o Aspose.Slides em um ambiente virtual?**

Sim. Você pode instalá‑lo em qualquer ambiente virtual Python com pip. As bibliotecas nativas que o Linux e o macOS precisam são instaladas no sistema, não no ambiente virtual.

**Posso usar o Aspose.Slides em contêineres Docker?**

Sim. A imagem deve incluir as mesmas bibliotecas nativas de um sistema Linux — libgdiplus e ICU — e as fontes que suas apresentações utilizam.

**Existe uma versão gratuita ou limitação de avaliação?**

Sim. Sem uma licença, o Aspose.Slides funciona em modo de avaliação: ele adiciona uma marca d’água de avaliação a cada slide salvo e trunca o texto lido das apresentações. Para remover estas limitações, aplique uma [license](/slides/pt/python-net/licensing/) válida.