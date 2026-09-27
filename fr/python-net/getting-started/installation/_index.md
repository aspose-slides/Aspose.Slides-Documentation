---
title: Installation
type: docs
weight: 70
url: /fr/python-net/installation/
keywords:
- télécharger Aspose.Slides
- installer Aspose.Slides
- utiliser Aspose.Slides
- installation d'Aspose.Slides
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Installez Aspose.Slides for Python via .NET depuis PyPI avec pip sur Windows, Linux et macOS, et installez les bibliothèques natives requises par Linux et macOS."
---
## **Vue d'ensemble**

Cet article explique comment installer Aspose.Slides for Python via .NET sur Windows, Linux et macOS. Le package est publié sur [PyPI](https://pypi.org/project/aspose.slides/) et installé avec pip. Il inclut le runtime .NET qu'il utilise, vous n’avez donc pas besoin d’installer .NET. Sur Linux et macOS, ce runtime nécessite des bibliothèques natives que le système d’exploitation peut ne pas inclure ; les sections ci‑dessous les nomment.

Aspose.Slides for Python via .NET prend en charge Python 3.5 à 3.14. PyPI propose des packages pour Windows (32 bits et 64 bits), Linux (x86_64 et ARM64) et macOS (Intel et Apple silicon).

## **Windows**

Sur Windows, installez le package avec pip. Aucune autre bibliothèque n’est requise.

```bash
pip install aspose.slides
```

## **Linux**

Sur Linux, le runtime .NET inclus dans le package nécessite deux bibliothèques :

- **libgdiplus**, une implémentation de l’API graphique Windows GDI+. Sans elle, l’enregistrement d’une présentation échoue avec l’erreur `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Sans elle, le processus Python se termine dès le premier appel à Aspose.Slides avec le message `Couldn't find a valid ICU package installed on the system`.

Sur Debian et Ubuntu, installez les deux avec apt :

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

Le nom du package ICU contient sa version : `libicu76` est le package pour Debian 13. Sur Debian 12, installez `libicu72` à la place, et sur Ubuntu 24.04, `libicu74`. Pour trouver le nom sur votre système, exécutez :

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Ensuite, installez le package dans un environnement virtuel. Sur les versions actuelles de Debian et Ubuntu, le Python système n’autorise pas `pip install` en dehors d’un environnement virtuel et s’arrête avec l’erreur `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Exécutez vos scripts avec le même environnement virtuel activé. Si vous utilisez un Python que votre distribution ne gère pas, comme celui des images Docker officielles `python`, vous pouvez également exécuter `pip install aspose.slides` sans environnement virtuel.

Les polices utilisées dans vos présentations, ou des substituts appropriés, doivent être installées sur le système pour que le texte s’affiche correctement lors de la conversion des diapositives en PDF ou en images.

## **macOS**

Nous n’avons pas vérifié l’installation sur macOS. Sur macOS, Aspose.Slides nécessite les prérequis suivants :

- **Python avec bibliothèques partagées**, c’est‑à‑dire Python compilé avec l’option de configuration `--enable-shared`. Si vous installez Python avec [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos), définissez la variable d’environnement `PYTHON_CONFIGURE_OPTS` à `--enable-shared` lors de l’installation d’une version de Python.
- **La bibliothèque libpython dans un répertoire de bibliothèques système.** Un Python installé avec pyenv conserve sa bibliothèque libpython, comme *libpython3.9.dylib*, sous *~/.pyenv/versions* ; créez un lien symbolique vers celle‑ci dans */usr/local/lib*.
- **libgdiplus**, une implémentation de l’API graphique Windows GDI+. Homebrew le fournit sous le package `mono-libgdiplus`.

Installez ensuite le package avec pip.

## **Vérifier l'installation**

Pour vérifier l’installation, enregistrez le premier exemple de [Create Presentations](/slides/fr/python-net/create-presentation/) sous le nom *hello.py* et exécutez `python hello.py`. Il enregistre *new_presentation.pptx* dans le dossier courant.

## **Mise à jour**

Pour mettre à jour une installation existante vers la dernière version, exécutez cette commande dans l’environnement où vous avez installé le package :

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Puis‑je installer Aspose.Slides dans un environnement virtuel ?**

Oui. Vous pouvez l’installer dans n’importe quel environnement virtuel Python avec pip. Les bibliothèques natives requises par Linux et macOS sont installées sur le système, pas dans l’environnement virtuel.

**Puis‑je utiliser Aspose.Slides dans des conteneurs Docker ?**

Oui. L’image doit inclure les mêmes bibliothèques natives qu’un système Linux — libgdiplus et ICU — ainsi que les polices utilisées par vos présentations.

**Existe‑t‑il une version gratuite ou une limitation d’essai ?**

Oui. Sans licence, Aspose.Slides fonctionne en mode d’évaluation : il ajoute un filigrane d’évaluation à chaque diapositive enregistrée et tronque le texte lu depuis les présentations. Pour supprimer ces limitations, appliquez une [licence](/slides/fr/python-net/licensing/) valide.